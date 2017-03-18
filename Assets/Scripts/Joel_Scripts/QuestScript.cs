using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour {

    public UITextHandler textHandling;

    public Text t_questName;
    public Text t_questDescription;
    public Text t_questTask;  //Text to be changed (showing the quest task)

    string questName;
    string questDescription;
    string questTask;

    int killed = 0;         //Amount killed
    int toBeKilled = 2;    //Amount to be killed
    bool questComplete = false;

    public List<Quest> quests = new List<Quest>();
    List<string> questListName = new List<string>();

    void Start()
    {
        textHandling = GetComponent<UITextHandler>();

        t_questName.gameObject.SetActive(true);
        t_questDescription.gameObject.SetActive(true);
        t_questTask.gameObject.SetActive(true);

        SpiderQuest2(); //Quest Start
        
        ZombieQuest(); //Quest Start
        
    }

    void Update()
    {
        if (textHandling.questBrowser.value == 0)
        {
            //ChangeText(questName, questDescription, questTask);
        }
        if (textHandling.questBrowser.value == 0)
        {
           // ChangeText(questName, questDescription, questTask);
        }
    }



    //Add Quests Here:

    public void ZombieQuest()
    {
        string qName = "Zombie Quest";
        string qDesc = "This quest will involve Zombie killing. Have fun and good luck... and BrAAAAAAAiinnss!!";
        string qTask = "Kill Zombies!";
        int task1 = 0;           //e.g. Amount killed
        int taskMax1 = 10;       //e.g. Amount to be killed
        bool questComplete = false;

        questName = qName;
        questDescription = qDesc;
        questTask = qTask;

        questListName.Clear();
        questListName.Add(qName);

        quests.Add(new Quest(questName, questDescription, questTask, task1, taskMax1, questComplete));
        textHandling.questBrowser.AddOptions(questListName);
        

    }

    public void SpiderQuest2()
    {

        string qName = "SpiderQuestTwo";
        string qDesc = "This quest will involve spider killing. Have fun and good luck!";
        string qTask = "Kill Spiders";
        int task1 = 0;           //e.g. Amount killed
        int taskMax1 = 10;       //e.g. Amount to be killed
        bool questComplete = false;

        questName = qName;
        questDescription = qDesc;
        questTask = qTask;
       
        questListName.Clear();
        questListName.Add(qName);

        quests.Add(new Quest(questName, questDescription, questTask, task1, taskMax1, questComplete));
        textHandling.questBrowser.AddOptions(questListName);
        

    }

    public void SpiderQuest() //Called everytime a spider dies (in the script "ItemDrop"->"DropItem()")
    {
        t_questName.text = "Spider Mess";
        t_questDescription.text = "Spiders. I don't like them. Kill them. You will be rewarded.";

        killed++; //Spider was killed
        if (killed >= toBeKilled)
        {
            killed = toBeKilled;
            t_questTask.color = Color.gray;
            questComplete = true;
        }
        t_questTask.text = killed.ToString() + "/" + toBeKilled.ToString() + " Spiders Slain"; //Update quest text
    }



    //Not Used:

    public void ChangeText(string qName, string qDesc, string qTask)
    {
        t_questName.text = qName;
        t_questDescription.text = qDesc;
        t_questTask.text = qTask;
    }
}


