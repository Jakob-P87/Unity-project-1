using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    public GameObject target;
    private float distToTarget;
    Vector3 lastSeen;
    Vector3 startPos;
    NavMeshAgent agent;
    enemyStates enemyState;

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

        if (distToTarget < 60 && hit.collider.tag == "Player")
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            Debug.Log("Hit!");
        }
    }
}