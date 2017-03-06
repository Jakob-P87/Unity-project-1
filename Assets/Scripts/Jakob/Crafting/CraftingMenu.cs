using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingMenu : MonoBehaviour
{
    public Vector2 pos;
    public Texture2D pot;

    public ItemDatabase database;
    public Inventory inventory;
    bool showCrafting = false;

    [SerializeField]
    GameObject CraftingUI;

    bool itemExist;

    void Start()
    {
        CraftingUI.SetActive(showCrafting);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        showCrafting = !showCrafting;
        CraftingUI.SetActive(showCrafting);
    }

    public void CraftPot(int type)
    {
        //Check to see if we have a mushroom and a water bottle in the inventory before we can craft the potion.
        if (inventory.ItemExist("Red Mushroom") && inventory.ItemExist("Water Bottle"))
        {
            craftItem(database.database[2]);
            inventory.RemoveItem("Red Mushroom");
            inventory.RemoveItem("Water Bottle");
            //level.curXp += (level.level + 50) / level.level + 3;
        }
    }

    public void craftItem(Item item)
    {
        inventory.AddItem("Health Potion");
    }



}
