using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionScript : MonoBehaviour {

    public Transform playerObject;
    public int detectionRange;
    public bool playerDetected;
    
    // Use this for initialization
    void Start () {
	}
	// Update is called once per frame
	void FixedUpdate () {
        if(inRange())
        {
            playerDetected = true;
            //Get Aggro (and attack?)!
        }
        else if(outOfRange())
        {
            playerDetected = false;
            //Stop Aggro
        }
	}
    bool inRange()
    {
        if (Vector3.Distance(transform.position, playerObject.position) < detectionRange)
        {
            return true;
        }
        return false;
    }
    bool outOfRange()
    {
        if (Vector3.Distance(transform.position, playerObject.position) < detectionRange+20)
        {
            return true;
        }
        return false;
    }
}
