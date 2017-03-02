using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public UserStats stats;

    Rect rect = new Rect(32, 600, 200, 50);

    string lvText = "Lv:";

    public GUIStyle guiLevel;

    // Use this for initialization
    void Start ()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<UserStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        LevelUp();
	}

    void LevelUp()
    {
        if (stats.curXp >= ((stats.level + 100) * stats.level + 13))
        {
            stats.curXp = 0;
            stats.level++;
<<<<<<< HEAD
            stats.curStrength += 3;
            stats.curVitality += 2;
            stats.curDexterity += 2;
            stats.curHp = stats.maxHp;
=======
>>>>>>> 877372159c6297e09d968a10eef6236129e37d98
        }
    }
}
