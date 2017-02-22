using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    playerUI ui;
    playerStates playerState;
<<<<<<< HEAD
    int layerMask = ~(1 << 8);

    void Start()
    {
        playerState = playerStates.WAKEUP;
=======
    public UserStats stats;

    void Start()
    {
        stats = GetComponent<UserStats>();
        playerState = playerStates.IDLE;
>>>>>>> 20e05853cfa249a0964ccc2e67655e2b7815a750
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        ui = GetComponent<playerUI>();
    }

    void Update()
    {
        Debug.Log(playerState);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            playerState = playerStates.IDLE;
        }
        if (Input.GetMouseButton(0) && playerState != playerStates.WAKEUP)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 9999999999, layerMask))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > 1) //Play running anim
        {
            playerState = playerStates.RUNNING;
        }
        else if (agent.remainingDistance < 1 && playerState != playerStates.WAKEUP) //Stop all animations
        {
            playerState = playerStates.IDLE;
        }
        if (stats.curHp <= 0) //Play death anim
        {
            playerState = playerStates.DEAD;
        }

        switch (playerState)
        {
            case playerStates.RUNNING:
                anim.SetBool("IsRunning", true);
                break;
            case playerStates.ATTACKING:
                anim.SetBool("IsAttacking", true);
                break;
            case playerStates.DEAD:
                anim.SetBool("IsDead", true);
                break;
            case playerStates.IDLE:
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsDead", false);
                break;
            case playerStates.WAKEUP:
                break;
        }
    }
}