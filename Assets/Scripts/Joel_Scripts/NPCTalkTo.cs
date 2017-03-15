using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalkTo : MonoBehaviour {

    public Text npcName;
    public Text dialougeText;

    string temp;

    void Start()
    {
        
    }

    void OnMouseDown()
    {
       TalkToNPC();   
    }

    void TalkToNPC()
    {

        npcName.text = gameObject.name;
        dialougeText.text = "Hello, my name is " + gameObject.name + ". What's your name?";

    }

}
