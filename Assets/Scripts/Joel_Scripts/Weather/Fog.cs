using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {

    //Default Fog Values
    public int fogStart = 20;
    public int fogEnd = 31;

    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = Color.white;
        RenderSettings.fogMode = FogMode.Linear;
    }

    void Update()
    {
        RenderSettings.fogStartDistance = fogStart;
        RenderSettings.fogEndDistance = fogEnd;
    }
}
