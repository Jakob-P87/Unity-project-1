using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinimapLookat : MonoBehaviour
{
    public GameObject player;
    public float cameraZoom;

    void Start()
    {
    }

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.y += cameraZoom;
        transform.position = pos;
    }
}
