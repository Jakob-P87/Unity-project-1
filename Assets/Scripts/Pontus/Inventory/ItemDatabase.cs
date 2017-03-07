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
        database.Add(new Item(itemType.Weapon, 0, "Wooden Sword", 2, 0, "Baby's first sword", new Recipe("Stick", "String")));
        database.Add(new Item(itemType.Material, 1, "Red Flower", 1, 0, "A red flower", new Recipe(null, null)));
        database.Add(new Item(itemType.Consumable, 2, "Health Potion", 0, 0, "Drink to restore some health", new Recipe("Red Mushroom", "Water Bottle")));
        database.Add(new Item(itemType.Armor, 3, "Chain Mail", 0, 5, "A normal chain mail", new Recipe(null, null)));
        database.Add(new Item(itemType.Material, 4, "Red Mushroom", 0, 0, "Used to make potions", new Recipe(null, null)));
        database.Add(new Item(itemType.Material, 5, "Water Bottle", 0, 0, "Used to make potions", new Recipe(null, null)));
        database.Add(new Item(itemType.Weapon, 6, "Iron Sword", 5, 0, "A bit better than the Wooden Sword", new Recipe("Iron", "Stick")));
        database.Add(new Item(itemType.Material, 7, "Stick", 0, 0, "A normal stick", new Recipe(null, null)));
        database.Add(new Item(itemType.Material, 8, "String", 0, 0, "A piece of string", new Recipe(null, null)));
        database.Add(new Item(itemType.Material, 9, "Iron", 0, 0, "Some iron for a sword", new Recipe(null, null)));
    }
}
