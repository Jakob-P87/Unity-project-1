using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inventory : MonoBehaviour {

    public int slotsX, slotsY;
    public Vector2 pos;
    public ItemDatabase database;
    bool showInventory = false;
    public List<Item> inventory = new List<Item>();
    float distToPickup;
    [HideInInspector]
    public List<Item> slots = new List<Item>();
    

    private void Start()
    {
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Pickup")
            {
                distToPickup = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, hit.transform.position);
                if (distToPickup <= 4.0f)
                {
                    AddItem(hit.collider.name);
                    DestroyObject(hit.transform.gameObject);
                }
            }
        }
    }

    void OnGUI()
    {
        if (showInventory)
        {
            DrawInventory();
        } 
    }

    void DrawInventory()
    {
        int i = 0;
        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)                
            {
                Rect slotRect = new Rect(60 * x + pos.x, 60 * y + pos.y, 50, 50);
                GUI.Box(slotRect, "");
                slots[i] = inventory[i];
                if (slots[i].m_name != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].m_icon);
                }

                i++;
            }
        }
    }

    public void AddItem(string name)
    {
        for (int i = 0; i < inventory.Count; i++)
        {            
            if(inventory[i].m_name == null)
            {
                for (int j = 0; j < database.database.Count; j++)
                {
                    if (database.database[j].m_name == name)
                    {
                        inventory[i] = database.database[j];
                    }
                }
                break;
            }                     
        }
    }
}
