using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{

    playerMovement player;
    UserStats stats;
    Animator anim;
    public enemyUI enemy;
    private float distToTarget;
    GameObject target;
    bool attacking;

    void Start()
    {

        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<UserStats>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {   
        if (Input.GetMouseButton(0) && !attacking)
        {
            StartCoroutine(AttackCooldown());
        }
    }

    void MeleeSwing()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Enemy" && (Vector3.Distance(transform.position, hit.collider.transform.position) < stats.baseAttackRange) && player.playerState != playerStates.WAKEUP)
        {
            player.agent.Stop();
            player.LookAt(hit.collider.transform);
            anim.speed = 3;
            anim.Play("Attack");
            enemy = hit.collider.gameObject.GetComponent<enemyUI>();
            enemy.currentHp -= stats.curAttackPower;
        }
    }

    IEnumerator AttackCooldown()
    {
        attacking = true;
        MeleeSwing();
        float delay = 8 - (stats.curAttackSpeed);
        if (delay <= 0.33f)
        {
            delay = 0.33f;
        }
        else if(delay >= 1.5f)
        {
            delay = 1.5f;
        }
        yield return new WaitForSeconds(delay);
        attacking = false;
        yield break;
    }
}