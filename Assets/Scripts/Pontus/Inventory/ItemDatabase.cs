﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> database = new List<Item>();
    bool openInv;

    [HideInInspector]
    public Item item;
    

    void Start()
    {
        database.Add(new Item(itemType.Weapon, 0, "Wooden Sword", 1, 0, "Baby's first sword"));
        database.Add(new Item(itemType.Material, 1, "Red Flower", 1, 0, "A red flower"));
        database.Add(new Item(itemType.Armor, 2, "Chain Mail", 0, 5, "A normal chain mail"));
        database.Add(new Item(itemType.Material, 3, "Red Mushroom", 0, 0, "Used to make potions"));
    }

    void Update()
    {
    }
}
