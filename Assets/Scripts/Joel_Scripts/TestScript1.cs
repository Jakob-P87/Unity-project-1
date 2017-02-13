using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript1 : MonoBehaviour {

    // Use this for initialization
    void Start () {

        Debug.Log("WHAT?");


    }
	
	// Update is called once per frame
	void Update () {

        



	}
}

public class SubClassOne : TestScript1
{

    public int oneInt;
   

}

public class SubClassTwo : TestScript1
{

    public int twoInt;

}
