using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour {
    public Image ItemIcon;
    public Text StackSize;

    Sprite tex;

    public void DragItem()
    {
        tex = gameObject.GetComponent<Image>().sprite;
        if (tex.name != "Background")
        {
            Cursor.SetCursor(tex.texture, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}