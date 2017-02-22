using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
    public int slotsX, slotsY;
    public Vector2 pos;
    public ItemDatabase database;
    public Inventory inventory;
    bool showCrafting = false;
    public Texture2D pot;

    bool itemExist;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            showCrafting = !showCrafting;
        }
    }

    void OnGUI()
    {
        if (showCrafting)
        {
            DrawCrafting();
        }
    }

    void DrawCrafting()
    { 
        Rect slotRect = new Rect(pos.x, pos.y, 150, 300);
        GUI.Box(slotRect, "");

        Rect button = new Rect(pos.x + 10, pos.y + 10, 50, 50);

        if (GUI.Button(button, pot))
        {
            //Check to see if we have a mushroom and a water bottle in the inventory before we can craft the potion.
            if (inventory.ItemExist("Red Mushroom") && inventory.ItemExist("Water Bottle"))
            {
                craftItem(database.database[2]);
                inventory.RemoveItem("Red Mushroom");
                inventory.RemoveItem("Water Bottle");
            }
        }
    }

    void craftItem(Item item)
    {
        inventory.AddItem("Health Potion");
    }
}
