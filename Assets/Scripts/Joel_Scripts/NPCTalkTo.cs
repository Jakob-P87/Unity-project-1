using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalkTo : MonoBehaviour {
    public enum CharacterState
    {
        GREETINGS,
        AWAIT,
        TURNIN,
        DONE,
    }

    [SerializeField]
    private GameObject QuestMark;

    public GameObject dialougeScreen;
    public Text npcName;
    public Text dialougeText;
    QuestScript questScript;
    public UserStats level;

    public CharacterType NPC;
    public CharacterState state = CharacterState.GREETINGS;

    bool talking = false;
    string temp;

    void Start()
    {
        //dialougeScreen.gameObject.SetActive(false);
        questScript = FindObjectOfType(typeof(QuestScript)) as QuestScript;
        level = FindObjectOfType(typeof(UserStats)) as UserStats;
        dialougeScreen.gameObject.SetActive(false);
    }

    void OnMouseUp()
    {
        if(!talking)
       TalkToNPC();      
    }

    void TalkToNPC()
    {
        dialougeScreen.gameObject.SetActive(true);
        npcName.text = gameObject.name;
        //dialougeText.text = "Hello, my name is " + gameObject.name + ". who are you?";
        talking = true;

        switch(NPC)
        {
            case CharacterType.KNIGHT:
                StartCoroutine(talkingToKnight());
                questScript.ZombieQuest();
                
                break;
            case CharacterType.RANGER:
                StartCoroutine(talkingToRanger());
                questScript.ZombieQuest(); // Start a Spider Quest
                break;
            case CharacterType.WIZARD:
                StartCoroutine(talkingToWizard());
                questScript.SpiderQuest2(); // Start a Spider Quest
                break;

            default:
                break;
        }

        
    }

    IEnumerator talkingToKnight()
    {
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Paladin?";
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Great. I need a paladin to take care of an un-dead problem.";
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Some zombies i need to become dead-dead. kthxbye.";
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        yield return new WaitForSeconds(0.1f);
        dialougeScreen.gameObject.SetActive(false);
        talking = false;
    }
    IEnumerator talkingToRanger()
    {

        if (state == CharacterState.AWAIT && GetQuestByGiver(CharacterType.RANGER).PendingTurnIn())
        {
            state = CharacterState.TURNIN;
        }

        switch (state)
        {
            case CharacterState.GREETINGS:
                dialougeText.text = "Greetings Stranger!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "You arrived at a good time!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "The cemetary has been infested with the living dead!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "Would you be kind and clear the cemetary for me?";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                yield return new WaitForSeconds(0.1f);
                dialougeScreen.gameObject.SetActive(false);
                talking = false;
                state = CharacterState.AWAIT;
                Destroy(QuestMark);
                break;

            case CharacterState.AWAIT:
                dialougeText.text = "Greetings Paladin!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "Have you cleared the cemetary yet?";
                //yield return new WaitForSeconds(0.4f);
                //yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                //dialougeText.text = "The cemetary has been infested with the living dead";
                //yield return new WaitForSeconds(0.4f);
                //yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                //dialougeText.text = "Would you be interested in clearing the cemetary for me?";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                yield return new WaitForSeconds(0.1f);
                dialougeScreen.gameObject.SetActive(false);
                talking = false;
                break;

            case CharacterState.TURNIN:
                dialougeText.text = "Greetings Paladin!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "So you cleared the cemetary, Well done!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "Now they can rest in peace!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "Good luck in the future!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                yield return new WaitForSeconds(0.1f);
                dialougeScreen.gameObject.SetActive(false);
                CompleteAllUnDeliveredQuests();
                talking = false;
                state = CharacterState.DONE;
                break;

            case CharacterState.DONE:
                dialougeText.text = "Greetings paladin!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "I have no work for you.";
                //CompleteAllUnDeliveredQuests();
                //yield return new WaitForSeconds(0.4f);
                //yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                //dialougeText.text = "Come back when you are done.";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                yield return new WaitForSeconds(0.1f);
                dialougeScreen.gameObject.SetActive(false);
                talking = false;

                break;
        }

    }

    IEnumerator talkingToWizard()
    {
        if (state == CharacterState.AWAIT && GetQuestByGiver(CharacterType.WIZARD).PendingTurnIn())
        {
            state = CharacterState.TURNIN;
        }

        switch(state)
        {
            case CharacterState.GREETINGS:
                //yield return new WaitForSeconds(0.4f);
                //yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "Greetings stranger!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "How about killing some spiders for me?";
                //CompleteAllUnDeliveredQuests();
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "Come back when you are done.";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                yield return new WaitForSeconds(0.1f);
                dialougeScreen.gameObject.SetActive(false);
                talking = false;
                state = CharacterState.AWAIT;
                Destroy(QuestMark);
                break;

            case CharacterState.AWAIT:
                dialougeText.text = "Greetings paladin!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "Are you done with your task yet?";
                //CompleteAllUnDeliveredQuests();
                //yield return new WaitForSeconds(0.4f);
                //yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                //dialougeText.text = "Come back when you are done.";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                yield return new WaitForSeconds(0.1f);
                dialougeScreen.gameObject.SetActive(false);
                talking = false;

                break;

            case CharacterState.TURNIN:
                dialougeText.text = "Greetings paladin!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "So you succeded in killing the spiders, Well done!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "Good luck with your journey!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                yield return new WaitForSeconds(0.1f);
                dialougeScreen.gameObject.SetActive(false);
                CompleteAllUnDeliveredQuests();
                talking = false;
                state = CharacterState.DONE;
                break;

            case CharacterState.DONE:
                dialougeText.text = "Greetings paladin!";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                dialougeText.text = "I have no work for you.";
                //CompleteAllUnDeliveredQuests();
                //yield return new WaitForSeconds(0.4f);
                //yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                //dialougeText.text = "Come back when you are done.";
                yield return new WaitForSeconds(0.4f);
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                yield return new WaitForSeconds(0.1f);
                dialougeScreen.gameObject.SetActive(false);
                talking = false;

                break;

        }
        
    }

    Quest GetQuestByGiver(CharacterType type)
    {
        foreach (Quest q in questScript.quests)
        {
            if (q.m_questGiver == type)
                return q;
        }

        return null;
    }

    void CompleteAllUnDeliveredQuests()
    {
        for (int i = 0; i < questScript.quests.Count; i++)
        {
            //if (questScript.quests[i].m_completed && questScript.quests[i].m_questDelivered == false)
            if (questScript.quests[i].PendingTurnIn())
            {
                level.curXp += questScript.quests[i].m_questReward; //Give curXp questReward amount (for every completed quest)
                questScript.completedQuestsList.Add(questScript.quests[i].m_questName);
                questScript.quests[i].m_questDelivered = true;
               
            }
        }
        questScript.textHandling.questBrowser.ClearOptions();
        questScript.questListName.Clear();
        for (int i = 0; i < questScript.quests.Count; i++)
        {
            if (!questScript.quests[i].m_completed)
            {
                questScript.questListName.Add(questScript.quests[i].m_questName);
            }
        }
        for (int i = 0; i < questScript.quests.Count; i++)
        {
            if(questScript.quests[i].m_completed)
                questScript.quests.RemoveAt(i);
        }
        questScript.textHandling.questBrowser.AddOptions(questScript.questListName);
        //for (int i = 0; i < questScript.quests.Count; i++)
        //{
        //    if(!questScript.quests[i].m_completed)
        //    {
        //        questScript.questListName.Add(questScript.quests[i].m_questName);
        //    }
        //}
        //questScript.textHandling.questBrowser.AddOptions(questScript.questListName);
    }
}
