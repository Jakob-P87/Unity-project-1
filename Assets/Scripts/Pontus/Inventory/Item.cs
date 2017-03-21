using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

    public itemType m_type;
    public EquipmentTypes m_equipType;
    public int m_id;
    public string m_name;
    public string m_desc;
    public int m_dmg;
    public Sprite m_icon;
    public int m_stackSize = 1;
    public Recipe m_recp;

    //Material
    public Item(int id, string name, string desc, int stackSize = 1)
    {
        m_type = itemType.Material;
        m_id = id;
        m_icon = Resources.Load<Sprite>("ItemIcons/" + name);
        m_name = name;
        m_desc = desc;
        m_stackSize = stackSize;
    }

    //Equipment
    public Item(int id, string name, int dmg, string desc, Recipe recp, EquipmentTypes equipType, int stackSize = 1)
    {
        m_type = itemType.Equipment;
        m_equipType = equipType;
        m_id = id;
        m_icon = Resources.Load<Sprite>("ItemIcons/" + name);
        m_name = name;
        m_dmg = dmg;
        m_desc = desc;
        m_recp = recp;
        m_stackSize = stackSize;
    }

    //Consumble
    public Item(int id, string name, string desc, Recipe recp, int stackSize = 1)
    {
        m_type = itemType.Consumable;
        m_id = id;
        m_icon = Resources.Load<Sprite>("ItemIcons/" + name);
        m_name = name;
        m_desc = desc;
        m_recp = recp;
        m_stackSize = stackSize;
    }

    //Copy Constructor
    public Item(Item itemOther)
    {
        m_type = itemOther.m_type;
        m_id = itemOther.m_id;
        m_name = itemOther.m_name;
        m_icon = Resources.Load<Sprite>("ItemIcons/" + itemOther.m_name);
        m_dmg = itemOther.m_dmg;
        m_desc = itemOther.m_desc;
        m_recp = itemOther.m_recp;
        m_stackSize = itemOther.m_stackSize;
    }

    //Default/Empty
    public Item()
    {
    }
}