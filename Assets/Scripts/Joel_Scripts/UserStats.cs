using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStats : MonoBehaviour {

    public string username;
    public int level;
    public string userClass;

    public float curHp;
    public float maxHp;
    public float curEnergy;
    public float maxEnergy;

    public float baseAttackPower;
    public float curAttackPower;
    public float baseAttackSpeed;
    public float curAttackSpeed;
    public float baseDodge;
    public float curDodge;
    public float baseHitPercent;
    public float curHitPercent;

    public float hpRegenTimer;
    public float hpRegenAmout;
    public float energyRegenTimer;
    public float energyRegenAmount;

    public float curXp;
    public float maxXp;

    public bool isDead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
