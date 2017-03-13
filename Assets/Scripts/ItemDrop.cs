using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ItemDrop : MonoBehaviour
{
    public Transform drop;
    public Transform pos;
    public enemyUI sRef;
    Animator anim;
    Transform goRef;
    public enemyMovement enemy;
    NavMeshAgent agent;

    public UserStats level;

    QuestScript questTask;

    // Use this for initialization
    void Start()
    {
        //reference to spider object with the script enemyUI on itself
        //sRef = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyUI>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<enemyMovement>();
        agent = GetComponent<NavMeshAgent>();
        questTask = GameObject.FindObjectOfType(typeof(QuestScript)) as QuestScript; //Get QuestScript
    }

    // Update is called once per frame
    void Update()
    {
        if (sRef.currentHp <= 0) //if currentHp <= 0
        {
            //Debug.Log("Hello");
            agent.Stop();
            StartCoroutine(DestroyObj());
            anim.Play("Dead");
        }
    }
    IEnumerator DestroyObj()
    {
        //Debug.Log("mhmm");
        yield return new WaitForSeconds(2);
        DropItem();
        Destroy(gameObject);
        yield break;
    }
    void DropItem()
    {
        if (Random.value <= 1) //%30 percent chance to happen (1 = 100%)
        {
            goRef = Instantiate(drop, gameObject.transform.position, gameObject.transform.rotation); //creates object on a position (choose in the editor!)
            goRef.name = drop.name;
            questTask.SpiderQuest();//Calls Function so that QuestScript knows when a spider has been killed
        }
    }
}