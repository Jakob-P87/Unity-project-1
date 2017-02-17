using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    //Life/Resource
    public int Health; //Hit points
    public int Energy; //Resource for skills?

    //Offensive
    public int Damage;      //Points of damage dealt each attack
    public int AttackSpeed; //Attacks per second

    //Defensive
    public int Armor; //Protection against attacks

    //Speccable stats
    public int Vitality;    //Increases Health
    public int Strength;    //Increases Damage
    public int Intelligence;
    public int Dexterity;   //Increases Attack Speed

    //Utility
    public int MovementSpeed; //Traversal speed


    void Start()
    {
        
    }

}
