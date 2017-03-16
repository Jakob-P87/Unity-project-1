using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> database = new List<Item>();
    bool openInv;

    [HideInInspector]
    public Item item;
    
    void Start()
    {
        //Materials
        database.Add(new Item(1, "Red Flower", ""));
        database.Add(new Item(2, "Red Mushroom", "Used to make health potions"));
        database.Add(new Item(3, "Water Bottle", "Used to make health potions"));

        //Equipment
        database.Add(new Item(4, "Wooden Sword", 2, "Baby's first sword", new Recipe("Stick", "String")));
        database.Add(new Item(5, "Iron Sword", 5, "A simple iron sword", new Recipe("Iron", "Stick")));
        database.Add(new Item(6, "Chain Mail", 3, "A chain mail", new Recipe(null, null)));

        //Consumable
        database.Add(new Item(7, "Health Potion", "A potion to restore health", new Recipe("Red Mushroom", "Water Bottle")));
    }

    void Update()
    {
    }
}