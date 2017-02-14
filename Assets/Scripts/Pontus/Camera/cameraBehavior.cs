using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehavior : MonoBehaviour {

    public GameObject player;
    public float cameraZoom;

    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.y += cameraZoom;
        pos.z -= cameraZoom;
        transform.position = pos;
    }
}