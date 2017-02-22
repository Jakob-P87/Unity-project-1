using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextOnScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

         void OnGUI()
         {
            GUI.Label(new Rect(800, 10, 200, 20), "Press Q to drink Health Potion!");
            GUI.Label(new Rect(800, 30, 200, 20), "Press I to show Inventory!");
            GUI.Label(new Rect(800, 50, 200, 20), "Press C to show Crafting Menu!");

         }
    
}
