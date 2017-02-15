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
    enemyStates enemyState;

    void Start ()
    {
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
                break;
            case enemyStates.CHASE:
                agent.Resume();
                agent.SetDestination(lastSeen);
                break;
            case enemyStates.ATTACK:
                agent.Stop();
                break;
            case enemyStates.RETURN:
                agent.Resume();
                agent.SetDestination(startPos);
                break;
            case enemyStates.DEAD:
                break;
        }
	}
    void Attack()
    {
        if (enemyState == enemyStates.ATTACK)
        {
            target.GetComponent<playerMovement>().hp -= 10;
        }
    }
}