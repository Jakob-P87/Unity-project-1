using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextHandler : MonoBehaviour {



    public GameObject lvlUpTxt;
    public GameObject questLog;
    public GameObject questNDT;
    public Dropdown questBrowser;

  

    public QuestScript questScript;



    bool showText = false;

	// Use this for initialization
	void Start () {


        lvlUpTxt.SetActive(showText);
        questScript = GetComponent<QuestScript>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.T))
        {
            ToggleQuestLog();
        }

        //Everything regarding quest texts changes when choosing corresponding option in the questBrowser(dropdown)
            questScript.t_questName.text = questScript.quests[questBrowser.value].m_questName;
            questScript.t_questDescription.text = questScript.quests[questBrowser.value].m_questDesc;
            questScript.t_questTask.text = questScript.quests[questBrowser.value].m_questTask;
        
    }

    void OnMouseDown()
    {
        
    }

    public IEnumerator textShowLevelUp()
    {
        showText = true;
        lvlUpTxt.SetActive(showText);
        yield return new WaitForSeconds(3f);
        showText = false;
        lvlUpTxt.SetActive(showText);
    }

    void ToggleQuestLog()
    {
        if (!questLog.activeSelf)
            questLog.SetActive(true);
        else if (questLog.activeSelf)
            questLog.SetActive(false);
    }
    
  


}
