using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalkTo : MonoBehaviour {

    public GameObject dialougeScreen;
    public Text npcName;
    public Text dialougeText;

    public CharacterType NPC;

    bool talking = false;
    string temp;

    void Start()
    {
        //dialougeScreen.gameObject.SetActive(false);
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
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Paladin?";
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Well it was nice to meet you.";
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        yield return new WaitForSeconds(1);
        dialougeScreen.gameObject.SetActive(false);
        talking = false;
    }
    IEnumerator talkingToRanger()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Paladin huh?";
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "I enjoy seeing new faces around here. See you later.";
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        yield return new WaitForSeconds(1);
        dialougeScreen.gameObject.SetActive(false);
        talking = false;
    }
    IEnumerator talkingToWizard()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "Paladin yes?";
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        dialougeText.text = "I'm sure our ways will cross again.";
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        yield return new WaitForSeconds(1);
        dialougeScreen.gameObject.SetActive(false);
        talking = false;
    }
}
