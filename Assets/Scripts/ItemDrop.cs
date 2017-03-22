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

    bool doneOnce = false;

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
        //Debug.Log(doneOnce);
        if (sRef.currentHp <= 0) //if currentHp <= 0
        {
            agent.Stop(); //Stops the object from moving when dead
            if (!doneOnce)
            {
                StartCoroutine(DestroyObj());
                anim.Play("Dead");
                doneOnce = true;
            }
        }
    }
    IEnumerator DestroyObj()
    {
            //Quest Related

        /*
        Instead of:

        if(characterType.CharacterType == CharacterType.SPIDER)
            questTask.quests[questTask.spiderQuestNum].m_task1++;
        if (characterType.CharacterType == CharacterType.ZOMBIE)
            questTask.quests[questTask.zombieQuestNum].m_task1++;
        */

        //Use this:   
        for (int i = 0; i < questTask.quests.Count; i++) //Checks all current quests
        {
            if(questTask.quests[i].m_mobType == characterType.CharacterType) //if a quest tasked to kill mob A == mob A
            {
                questTask.quests[i].m_task1++; //mob A.Killed++;
            }
        }



        questTask.QuestUpdate();
        //~Quest Related



        DropItem();
        yield return new WaitForSeconds(2);

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
 