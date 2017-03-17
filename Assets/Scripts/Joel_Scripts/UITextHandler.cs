using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextHandler : MonoBehaviour {



    public GameObject lvlUpTxt;
    public GameObject questLog;
    public GameObject questNDT;
    public Dropdown questBrowser;

    bool showText = false;

	// Use this for initialization
	void Start () {
        lvlUpTxt.SetActive(showText);
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.T))
        {
            ToggleQuestLog();
        }

        if (questBrowser.value == 0)
        {
            
        }

        
        
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
