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

    

    //public List<CraftingSlot> newRecipe = new List<CraftingSlot>();

    //[SerializeField]
    //GameObject CraftingRecipe;
    //[SerializeField]
    //GameObject CraftingUI;

    //public UserStats level;

    bool itemExist;

    void Start()
    {
        //GameObject craftingSlot = Instantiate(CraftingRecipe, CraftingUI.transform);
        //newRecipe.Add(craftingSlot.GetComponent<CraftingSlot>());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            showCrafting = !showCrafting;
        }
    }

    //void DrawCrafting()
    //{
    //    newRecipe[0].RecipeIcon.enabled = true;
    //    newRecipe[0].RecipeIcon.sprite = database.database[2].m_icon;
    //}

    //public void Toggle()
    //{
    //    showInventory = !showInventory;
    //    InventoryUI.SetActive(showInventory);
    //    DrawInventory();
    //}

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
                //level.curXp += (level.level + 50) / level.level + 3;
            }
        }
    }

    public void craftItem(Item item)
    {
        inventory.AddItem("Health Potion");
    }
}
