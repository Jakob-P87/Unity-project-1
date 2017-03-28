using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    public GameObject target; //player
    private float distToTarget;
    public float aggroRange;
    public float attackRange;
    public float attackDelay;
    public float attackDmg;
    public int addXp;
    Vector3 lastSeen;
    Vector3 startPos;
    NavMeshAgent agent;
    public enemyStates enemyState; //enum
    Animator anim;
    public UserStats level;
    public enemyUI enemy;

    void Start ()
    {
        anim = GetComponent<Animator>(); //the gameobjects animator
        InvokeRepeating("Attack", 0, attackDelay);
        enemyState = enemyStates.IDLE; 
        agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update ()
    {
        distToTarget = Vector3.Distance(transform.position, target.transform.position); //distance between gameobjects and targets positions
        RaycastHit hit;
        var castDir = target.transform.position - transform.position;
        Physics.SphereCast(transform.position, 1, castDir, out hit);

        if (distToTarget < aggroRange && distToTarget > attackRange && hit.collider.tag == "Player") //CHASE
        {
            lastSeen = target.transform.position; //players last known position
            enemyState = enemyStates.CHASE;
        }
        else if (distToTarget < attackRange && hit.collider.tag == "Player") //ATTACK
        {
            enemyState = enemyStates.ATTACK;
        }      
        else if (transform.position.x != startPos.x && (hit.collider.tag != "Player" || distToTarget > aggroRange)) //RETURN
        {
            enemyState = enemyStates.RETURN;
        }
        else if (transform.position.x == startPos.x)//IDLE
        {
            enemyState = enemyStates.IDLE; 
        }

        switch (enemyState)
        {
            case enemyStates.IDLE: //Idle animation
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsDead", false);
                anim.SetBool("IsIdle", true);
                break;
            case enemyStates.CHASE: //Running animation
                agent.Resume();
                agent.SetDestination(lastSeen); // go to last known position of the player
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsIdle", false);
                break;
            case enemyStates.ATTACK: //Attack animation
                agent.Stop();
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsAttacking", true);
                break;
            case enemyStates.RETURN: //Running animation
                agent.Resume();
                agent.SetDestination(startPos); //return to start position
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsIdle", false);
                break;
            case enemyStates.DEAD: //Dying animation
                anim.SetBool("IsDead", true);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsIdle", false);
                break;
        }
	}
    void Attack()
    {
        if (enemyState == enemyStates.ATTACK && enemy.currentHp > 0)
        {
            float dmg = attackDmg - level.curArmor;
            if (dmg < 1) //if armor is higher than dmg
            {
                dmg = 1; //dmg = 1
            }
                
            target.GetComponent<playerUI>().TakeDamage(dmg);
        }
    }

    void OnDestroy()
    {
        level.curXp += (level.level + addXp) / level.level + 3; //player xp system
    }
}