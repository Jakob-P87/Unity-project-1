using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItems : MonoBehaviour {

    int dragSlotID;
    int dropSlotID;
    Inventory inv;
    Item draggedItem = null;
    public Sprite backgroundSprite;
    PointerEventData data;

    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        data = new PointerEventData(null);
    }

    void Update()
    {
        if (Input.GetButtonDown("LeftMouseButton"))
        {
            GraphicRaycaster ray = gameObject.GetComponent<GraphicRaycaster>();
            data.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            ray.Raycast(data, results);
            
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.GetComponent<InventorySlot>() && draggedItem == null)
                {
                    dragSlotID = results[i].gameObject.GetComponent<InventorySlot>().slotID;
                    DragItem(dragSlotID);
                }
            }
        }
        else if (Input.GetButtonUp("LeftMouseButton"))
        {
            GraphicRaycaster ray = gameObject.GetComponentInParent<GraphicRaycaster>();
            data.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            ray.Raycast(data, results);

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.GetComponent<InventorySlot>() && draggedItem != null)
                {
                    dropSlotID = results[i].gameObject.GetComponent<InventorySlot>().slotID;
                    DropItem(dropSlotID);
                }
            }
            inv.DrawInventory();
        }
    }

    public void DragItem(int id)
    {
        Item item = inv.inventory[id];

        if (item.m_name != null)
        {
            draggedItem = new Item(item);
            inv.RemoveItem(draggedItem.m_name, draggedItem.m_stackSize);
        }
    }

    public void DropItem(int id)
    {
        Item item = inv.inventory[id];     

        if (item.m_name == null)
        {
            inv.inventory[id] = draggedItem;
            draggedItem = null;
        }
        else if (item.m_name != null) //This switches places of items
        {
            inv.inventory[dragSlotID] = inv.inventory[id];
            inv.inventory[id] = draggedItem;
            draggedItem = null;
        }
    }
}
