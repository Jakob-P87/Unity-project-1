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

    public void CraftItem(string itemName)
    {
        for (int i = 0; i < database.database.Count; i++)
        {
            if (database.database[i].m_name == itemName && inventory.HasRecipe(database.database[i]))
            {
                inventory.AddItem(itemName);
                inventory.RemoveItem(database.database[i].m_recp.m_material1);
                inventory.RemoveItem(database.database[i].m_recp.m_material2);
            }
        }
    }
}