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
    NavMeshAgent agent;
    enemyUI UI;

    public UserStats level;

    QuestScript questTask;
    GetObjectType characterType;

    // Use this for initialization
    void Start()
    {
        //reference to spider object with the script enemyUI on itself
        //sRef = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyUI>();
        UI = GetComponent<enemyUI>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        questTask = GameObject.FindObjectOfType(typeof(QuestScript)) as QuestScript; //Get QuestScript
        characterType = GetComponent<GetObjectType>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sRef.currentHp <= 0) //if currentHp <= 0
        {
            agent.Stop();
            StartCoroutine(DestroyObj());
            anim.Play("Dead");
        }
    }
    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(2);
        if (characterType.CharacterType == CharacterType.SPIDER) //Is the GameObject a spider?
            questTask.SpiderQuest();//Calls Function so that QuestScript knows when a spider has been killed
        DropItem();
        Destroy(UI.hp.gameObject);
        Destroy(gameObject);
        yield break;
    }
    void DropItem()
    {
        if (Random.value <= 1) //%30 percent chance to happen (1 = 100%)
        {
            goRef = Instantiate(drop, gameObject.transform.position, gameObject.transform.rotation); //creates object on a position (choose in the editor!)
            goRef.name = drop.name;
        }
    }
}