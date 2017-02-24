using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int currentExp;
    public int level;
    Rect rect = new Rect(32, 600, 200, 50);

    string lvText = "Lv:";

    public GUIStyle guiLevel;

    // Use this for initialization
    void Start ()
    {
        currentExp = 0;
        level = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        LevelUp();
	}

    void LevelUp()
    {
        if (currentExp >= ((level + 100) * level + 13))
        {
            currentExp = 0;
            level++;
        }
    }

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(rect, lvText + level, guiLevel);
    }
}
