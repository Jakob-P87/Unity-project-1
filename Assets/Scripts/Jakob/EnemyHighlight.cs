using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHighlight : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public Texture2D gameCursorTex;

    public Texture2D npcCursorTex;
    public Texture2D interactCursorTex;
    public Texture2D pickupCursorTex;
    public Texture2D enemyCursorTex;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.tag != "Untagged")
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
        switch (hit.collider.tag)
        {
            case "Enemy":
                Cursor.SetCursor(enemyCursorTex, hotSpot, cursorMode);
                break;
            case "Pickup":
                Cursor.SetCursor(pickupCursorTex, hotSpot, cursorMode);
                break;
            case "Interactable":
                Cursor.SetCursor(interactCursorTex, hotSpot, cursorMode);
                break;
            case "Npc":
                Cursor.SetCursor(npcCursorTex, hotSpot, cursorMode);
                break;
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(gameCursorTex, Vector2.zero, cursorMode);
    }


}
