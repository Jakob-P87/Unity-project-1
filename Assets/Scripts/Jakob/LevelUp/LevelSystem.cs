using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public UserStats stats;

    Rect rect = new Rect(32, 600, 200, 50);

    string lvText = "Lv:";

    public GUIStyle guiLevel;

    public GameObject particleEffectLevel;  //Get gameobject with a particle system in it: in this case the Level Up particle effect
    StartParticleTest sn;                   //sn = scriptName


    // Use this for initialization
    void Start ()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<UserStats>();
        sn = particleEffectLevel.GetComponent<StartParticleTest>();                     //Set sn to a gameobjects script<StartParticleTest>
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
            sn.PlayPartEff(); //Plays Particvle Effect for Leveling Up
            stats.curXp = 0;
            stats.level++;
            stats.curStrength += 3;
            stats.curVitality += 2;
            stats.curDexterity += 2;
            stats.curHp = stats.maxHp;
        }
    }
}
