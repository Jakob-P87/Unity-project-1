using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class playerMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    Animator anim;
    public playerStates playerState;
    int layerMask = ~(1 << 8);

    //int uiMask = (1 << 5);

    public UserStats stats;

    void Start()
    {
        stats = GetComponent<UserStats>();
        playerState = playerStates.WAKEUP;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && playerState != playerStates.ATTACKING)
        {
            playerState = playerStates.IDLE;
        }
        if (Input.GetMouseButton(0) && playerState != playerStates.WAKEUP)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the mouse was clicked over a UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                
                //Debug.Log("Clicked on the UI");
            }

            else if (Physics.Raycast(ray, out hit, 9999999999, layerMask) && hit.collider.tag != "Enemy")
            {
                agent.Resume();
                agent.SetDestination(hit.point);
                anim.speed = 1;
            }
        }

        if (agent.remainingDistance > 1) //Play running anim
        {
            playerState = playerStates.RUNNING;
        }
        else if (agent.remainingDistance < 1 && playerState != playerStates.WAKEUP && playerState != playerStates.ATTACKING) //Stop all animations
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
                anim.speed = 1;
                anim.SetBool("IsDead", true);
                playerState = playerStates.WAKEUP;
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

    public void LookAt(Transform target)
    {
            Vector3 targetDir = target.transform.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 2f, 1f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
    }
}