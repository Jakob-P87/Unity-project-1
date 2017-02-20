using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStats : MonoBehaviour {

    public string username; //Player Name

    public int level; //Player Level

    public float curXp;
    public float maxXp;

    public string userClass; //Player Class

    /*
     * base<var> = users raw stats (no items/buffs etc..)
     * cur<var> = users raw stats + item stats, buffs, etc..
     * 
    */

    //Player Lifeforce
    public float curHp;
    public float maxHp;

    public float curEnergy;
    public float maxEnergy;

    public float hpRegenTimer;
    public float hpRegenAmout;

    public float energyRegenTimer;
    public float energyRegenAmount;

    //Player Attack
    public float baseAttackPower;
    public float curAttackPower;

    public float baseAttackSpeed;
    public float curAttackSpeed;

    public float baseHitPercent;
    public float curHitPercent;

    //Player Defense
    public float baseArmor;
    public float curArmor;

    public float baseDodge;
    public float curDodge;











   

    /*
     * THOUGHT
     * if no buffs exists for speccable stats, cur<var> not needed.
    */
    public float baseStrength;
    public float curStrength;

    public float baseVitality;
    public float curVitality;

    public float baseDexterity;
    public float curDexterity;

    public float baseMovementSpeed;
    public float curMovementSpeed;


    public bool isDead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
