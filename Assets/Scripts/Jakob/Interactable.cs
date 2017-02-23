using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject go;
    [SerializeField]
    private Color startColor;
    
    public void OnHitByRaycast()
    {
        go.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", new Color(0.2f, 0.2f, 0.2f, 0.2f));
    }
    public void OnHitRaycastStop()
    {
        go.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", startColor);
    }
}
