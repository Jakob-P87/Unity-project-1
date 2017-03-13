using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextHandler : MonoBehaviour {



    public GameObject lvlUpTxt;

    bool showText = false;

	// Use this for initialization
	void Start () {
        lvlUpTxt.SetActive(showText);
    }

    public IEnumerator textShowLevelUp()
    {
        showText = true;
        lvlUpTxt.SetActive(showText);
        yield return new WaitForSeconds(3f);
        showText = false;
        lvlUpTxt.SetActive(showText);
    }

  


}
