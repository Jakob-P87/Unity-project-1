using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour {
    public Image ItemIcon;
    public Text StackSize;
    Inventory inv;
    Item draggedItem;
    Sprite tex;
    public Sprite backgroundSprite;

    public void DragItem()
    {
        tex = gameObject.GetComponent<Image>().sprite;
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

        for (int i = 0; i < inv.inventory.Count; i++)
        {
            if (tex.name == inv.inventory[i].m_name && tex.name != "Background")
            {
                draggedItem = inv.inventory[i];
                Debug.Log(draggedItem.m_stackSize);
                for (int j = 0; j < draggedItem.m_stackSize; j++)
                {
                    
                    inv.RemoveItem(draggedItem.m_name);
                   
                }
                //break;
            }
        }

        if (tex.name != "Background")
        {
            Cursor.SetCursor(tex.texture, Vector2.zero, CursorMode.Auto);
            gameObject.GetComponent<Image>().sprite = backgroundSprite;
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void DropItem()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

        for (int i = 0; i < inv.inventory.Count; i++)
        {
            if (inv.inventory[i].m_name == null)
            {
                inv.inventory[i] = draggedItem;
                Debug.Log(inv.inventory[i].m_name);
                break;
            }
        }
    }
}