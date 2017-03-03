using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    public GameObject target;
    private float distToTarget;
    public float aggroRange;
    public float attackRange;
    Vector3 lastSeen;
    Vector3 startPos;
    NavMeshAgent agent;
    public enemyStates enemyState;
    Animator anim;
    public UserStats level;
    public enemyUI enemy;

    void Start ()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("Attack", 0, 1.0f);
        enemyState = enemyStates.IDLE; 
        agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update ()
    {
        distToTarget = Vector3.Distance(transform.position, target.transform.position);
        RaycastHit hit;
        var castDir = target.transform.position - transform.position;
        Physics.SphereCast(transform.position, 1, castDir, out hit);

        if (distToTarget < aggroRange && distToTarget > attackRange && hit.collider.tag == "Player") //CHASE
        {
            lastSeen = target.transform.position;
            enemyState = enemyStates.CHASE;
        }
        else if (distToTarget < attackRange && hit.collider.tag == "Player") //ATTACK
        {
            enemyState = enemyStates.ATTACK;
        }
        else if (transform.position == lastSeen && enemyState == enemyStates.IDLE && (hit.collider.tag != "Player" || distToTarget < aggroRange)) //RETURN
        {
            enemyState = enemyStates.RETURN;
        }
        else //IDLE
        {
            enemyState = enemyStates.IDLE; 
        }

        switch (enemyState)
        {
            case enemyStates.IDLE:
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsDead", false);
                break;
            case enemyStates.CHASE:
                agent.Resume();
                agent.SetDestination(lastSeen);
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsAttacking", false);
                break;
            case enemyStates.ATTACK:
                agent.Stop();
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsAttacking", true);
                break;
            case enemyStates.RETURN:
                agent.Resume();
                agent.SetDestination(startPos);
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsAttacking", false);
                break;
            case enemyStates.DEAD:
                //level.curXp += (level.level + 50) / level.level + 3;
                anim.SetBool("IsDead", true);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsRunning", false);
                break;
        }
	}
    void Attack()
    {
        if (enemyState == enemyStates.ATTACK && enemy.currentHp > 0)
        {
            target.GetComponent<playerUI>().TakeDamage(10);
        }
    }
}