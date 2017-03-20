using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItems : MonoBehaviour {

    int dragSlotID;
    int dropSlotID;
    int equipSlotID;
    Inventory inv;
    Item draggedItem = null;
    Item equipedItem = null;
    PointerEventData data;
    GameObject player;
    GameObject goRef;
    ItemDatabase database;

    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        data = new PointerEventData(null);
        player = GameObject.FindGameObjectWithTag("Player");
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
    }

    void Update()
    {
        //Drag item
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
                //else if (results[i].gameObject.GetComponent<EquipmentSlot>() && draggedItem == null)
                //{
                //    dragSlotID = results[i].gameObject.GetComponent<EquipmentSlot>().equipSlotID;
                //    DragItem(dragSlotID);
                //}
            }
        }

        //Drop item
        if (Input.GetButtonUp("LeftMouseButton"))
        {
            GraphicRaycaster ray = gameObject.GetComponent<GraphicRaycaster>();
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

            if (results.Count == 0 && draggedItem != null)
            {
                Debug.Log("Result is empty");
                TossItem();
            }
            inv.DrawInventory();
        }

        //Equip item in inventory on right click
        if (Input.GetButtonDown("RightMouseButton"))
        {
            GraphicRaycaster ray = gameObject.GetComponent<GraphicRaycaster>();
            data.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            ray.Raycast(data, results);
            
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.GetComponent<InventorySlot>())
                {
                    equipSlotID = results[i].gameObject.GetComponent<InventorySlot>().slotID;
                    EquipItem(equipSlotID);
                }
            }
        }

        //Unequip item on right click
        if (Input.GetButtonDown("RightMouseButton"))
        {
            GraphicRaycaster ray = gameObject.GetComponent<GraphicRaycaster>();
            data.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            ray.Raycast(data, results);

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.GetComponent<EquipmentSlot>())
                {
                    dropSlotID = results[i].gameObject.GetComponent<EquipmentSlot>().equipSlotID;
                    UnequipItem(dropSlotID);
                }
            }
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

    public void EquipItem(int id)
    {
        Item item = inv.inventory[id];

        if (item.m_name != null && item.m_type == itemType.Equipment)
        {
            equipedItem = new Item(item);
            inv.AddEquipment(equipedItem.m_name);
            equipedItem = null;
        }
    }

    public void UnequipItem(int id)
    {
        Item item = inv.equipment[id];

        if (item.m_name != null && item.m_type == itemType.Equipment)
        {
            equipedItem = new Item(item);
            inv.RemoveEquipment(equipedItem.m_name);
            equipedItem = null;
        }
    }

    public void TossItem()
    {
        if (Resources.Load("Prefabs/" + draggedItem.m_name) == null)
        {
            inv.inventory[dragSlotID] = draggedItem;
            draggedItem = null;
        }
        else
        {
            for (int i = 0; i < draggedItem.m_stackSize; i++)
            {
                goRef = (GameObject)Instantiate(Resources.Load("Prefabs/" + draggedItem.m_name),
                         new Vector3(player.transform.position.x + Random.Range(-2f, 2f), player.transform.position.y, player.transform.position.z + Random.Range(-2f, 2f)),
                         player.transform.rotation);                
                goRef.name = draggedItem.m_name;
            }
            draggedItem = null;
        }
    }
}