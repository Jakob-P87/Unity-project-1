using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    NavMeshAgent agent;
    public GameObject target;
    enemyStates enemyState;
    private float distToTarget;

	void Start ()
    {
        enemyState = enemyStates.IDLE; 
        agent = GetComponent<NavMeshAgent>();
    }
	
	void Update ()
    {
        distToTarget = Vector3.Distance(transform.position, target.transform.position);
        RaycastHit hit;
        var castDir = target.transform.position - transform.position;

        Physics.SphereCast(transform.position, 1, castDir, out hit);
        //Debug.Log(hit.collider.tag);

        if (distToTarget < 50 && hit.collider.tag == "Player")
        {
            enemyState = enemyStates.CHASE;
        }
        else
        {
            enemyState = enemyStates.IDLE;
        }

        switch (enemyState)
        {
            case enemyStates.IDLE:
                agent.Stop();
                break;
            case enemyStates.CHASE:
                agent.Resume();
                agent.SetDestination(target.transform.position);
                break;
            case enemyStates.DEAD:
                break;
        }
	}
}