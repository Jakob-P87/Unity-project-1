﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    playerStates playerState;
    public UserStats stats;

    void Start()
    {
        stats = GetComponent<UserStats>();
        playerState = playerStates.IDLE;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > 1) //Play running anim
        {
            playerState = playerStates.RUNNING; 
        }
        else if (agent.remainingDistance < 1) //Stop all animations
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
        }
        
    }
}