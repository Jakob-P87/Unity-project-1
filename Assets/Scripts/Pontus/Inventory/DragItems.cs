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

    public void TossItem()
    {
        for (int i = 0; i < database.database.Count; i++)
        {
            if (draggedItem.m_id == database.database[i].m_id)
            {
                if (Resources.Load("Prefabs/" + draggedItem.m_name) == null)
                {
                    inv.inventory[dragSlotID] = draggedItem;
                    draggedItem = null;
                    break;
                }
                else
                {
                    for (int j = 0; j < draggedItem.m_stackSize; j++)
                    {
                        goRef = (GameObject)Instantiate(Resources.Load("Prefabs/" + draggedItem.m_name),
                                 new Vector3(player.transform.position.x + Random.Range(-2f, 2f), player.transform.position.y, player.transform.position.z + Random.Range(-2f, 2f)),
                                 player.transform.rotation);                
                        goRef.name = draggedItem.m_name;
                    }
                    draggedItem = null;
                    break;
                }
            }
        }
    }
}