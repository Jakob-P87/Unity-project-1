﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHighlight : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Enemy")
        {
            OnMouseEnter();
        }
        else
        {
            OnMouseExit();
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
