using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour {

    public Text questTask;  //Text to be changed (showing the quest task)

    int killed = 0;         //Amount killed
    int toBeKilled = 2;    //Amount to be killed

    void Start()
    {
        questTask.text = killed.ToString() + "/" + toBeKilled.ToString() + " Spiders Slain"; //Update quest text
    }

    public void SpiderQuest() //Called everytime a spider dies (in the script "ItemDrop"->"DropItem()")
    {
        killed++; //Spider was killed
        if (killed >= toBeKilled)
        {
            killed = toBeKilled;
            questTask.color = Color.gray;
        }
        questTask.text = killed.ToString() + "/" + toBeKilled.ToString() + " Spiders Slain"; //Update quest text

    }

}
