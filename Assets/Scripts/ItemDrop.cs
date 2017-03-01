using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrop : MonoBehaviour {
    public Transform drop;
    public Transform pos;

    float health;

    // Use this for initialization
    void Start () {
        //reference to spider object with the script enemyUI on itself
        GameObject spider_myOldOne = GameObject.Find("spider_myOldOne");
        enemyUI sRef = spider_myOldOne.GetComponent<enemyUI>();
        health = sRef.currentHp; //health = enemyUI's currentHp
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) //if currentHp <= 0
        {
            Destroy(gameObject); //removes the object
            if (Random.value <= 0.3) //%30 percent chance to happen (1 = 100%)
            {
                Instantiate(drop, pos.position, pos.rotation); //creates object on a position (choose in the editor!)
            }
        }
	}
}
