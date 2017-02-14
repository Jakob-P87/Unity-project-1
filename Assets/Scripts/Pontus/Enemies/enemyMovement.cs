using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    NavMeshAgent agent;
    public GameObject target;
    enemyStates enemyState;
    private float distToTarget;
    Vector3 lastSeen;
    Vector3 startPos;

	void Start ()
    {
        enemyState = enemyStates.IDLE; 
        agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;

    }
	
	void Update ()
    {
        distToTarget = Vector3.Distance(transform.position, target.transform.position);
        RaycastHit hit;
        var castDir = target.transform.position - transform.position;

        Physics.SphereCast(transform.position, 1, castDir, out hit);
        //Debug.Log(hit.collider.tag);

        if (distToTarget < 75 && hit.collider.tag == "Player")
        {
            lastSeen = target.transform.position;
            enemyState = enemyStates.CHASE;
        }
        else if (transform.position == lastSeen && enemyState == enemyStates.IDLE)
        {
            agent.SetDestination(startPos);
        }
        else
        {
            enemyState = enemyStates.IDLE;
        }

        switch (enemyState)
        {
            case enemyStates.IDLE:
                break;
            case enemyStates.CHASE:
                agent.SetDestination(lastSeen);
                break;
            case enemyStates.DEAD:
                break;
        }
	}
}