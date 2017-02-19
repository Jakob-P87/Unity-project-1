using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public int slotsX, slotsY;
    public ItemDatabase database;
    bool showInventory = false;
    public List<Item> inventory = new List<Item>();
    [HideInInspector]
    public List<Item> slots = new List<Item>();

    private void Start()
    {
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        AddItem("Wooden Sword");
        AddItem("Red Flower");
        AddItem("Red Flower");
        AddItem("Wooden Sword");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
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
                Rect slotRect = new Rect(60 * x, 60 * y, 50, 50);
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

    void AddItem(string name)
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
