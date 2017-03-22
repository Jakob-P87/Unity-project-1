using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMiniMap : MonoBehaviour {

    public Inventory inventory;

    bool showMiniMap = false;

    [SerializeField]
    GameObject Minimap;

    void Start ()
    {
        //Minimap.SetActive(showMiniMap);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        showMiniMap = !showMiniMap;
        Minimap.SetActive(showMiniMap);
    }
}
