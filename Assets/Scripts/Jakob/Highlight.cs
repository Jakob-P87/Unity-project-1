using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    //private Renderer rend;
    public Color startColor;
    [SerializeField]
    private GameObject mushroom;
    int layerMask = (1 << 9);
    private Interactable lastHit;

    void Start()
    {
        //rend = mushroom.GetComponent<Renderer>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 9999999999, layerMask))
        {
            // We hit an interactable!
            lastHit = hit.collider.GetComponent<Interactable>();
            lastHit.OnHitByRaycast();
        }
        else
        {
            if (lastHit)
            {
                lastHit.OnHitRaycastStop();
                lastHit = null;
            }
        }
    }
}
