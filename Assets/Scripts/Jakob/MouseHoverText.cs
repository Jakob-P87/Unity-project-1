using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject childText = null; //  or make public and drag

    void Start()
    {
        Text text = GetComponentInChildren<Text>();
        if (text != null)
        {
            childText = text.gameObject;
            childText.SetActive(false);
        }
    }

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("The cursor entered the selectable UI element.");
        childText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        childText.SetActive(false);
    }
}