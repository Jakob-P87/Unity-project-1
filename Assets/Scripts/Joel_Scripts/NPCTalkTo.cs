using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalkTo : MonoBehaviour {

    public GameObject dialougeScreen;
    public Text npcName;
    public Text dialougeText;
    QuestScript questScript;
    public UserStats level;

    public CharacterType NPC;

    bool talking = false;
    string temp;

    void Start()
    {
        //dialougeScreen.gameObject.SetActive(false);
        questScript = FindObjectOfType(typeof(QuestScript)) as QuestScript;
        level = FindObjectOfType(typeof(UserStats)) as UserStats;
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
        dialougeText.text = "Hello, my name is " + gameObject.name + ". who are you?";
        talking = true;

        switch(NPC)
        {
            case CharacterType.KNIGHT:
                StartCoroutine(talkingToKnight());
                questScript.SpiderQuest2(); // Start a Spider Quest
                break;
            case CharacterType.RANGER:
                StartCoroutine(talkingToRanger());
                break;
            case CharacterType.WIZARD:
                StartCoroutine(talkingToWizard());
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
        dialougeText.text = "Well it was nice to meet you.";
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        yield return new WaitForSeconds(0.1f);
        dialougeScreen.gameObject.SetActive(false);
        talking = false;
    }
    IEnumerator talkingToRanger()
    {
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Paladin huh?";
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "I enjoy seeing new faces around here. See you later.";
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        yield return new WaitForSeconds(0.1f);
        dialougeScreen.gameObject.SetActive(false);
        talking = false;
    }
    IEnumerator talkingToWizard()
    {
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Paladin yes?";
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Completed quests now rewarded";
        for (int i = 0; i < questScript.quests.Count; i++)
        {
            if (questScript.quests[i].m_completed)
            {
                level.curXp += questScript.quests[i].m_questReward; //Give curXp questReward amount (for every completed quest)
                //Make something here which wont give XP by talking again? Perhaps set m_completed = false? No cuz it will be set to true again...
            }
        }
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "I'm sure our ways will cross again.";
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        yield return new WaitForSeconds(0.1f);
        dialougeScreen.gameObject.SetActive(false);
        talking = false;
    }
}
