using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

    public itemType m_type;
    public int m_id;
    public string m_name;
    public string m_desc;
    public int m_dmg;
    public Sprite m_icon;
    public int m_stackSize = 1;
    public Recipe m_recp;

    //Material
    public Item(int id, string name, string desc)
    {
        m_type = itemType.Material;
        m_id = id;
        m_icon = Resources.Load<Sprite>("ItemIcons/" + name);
        m_name = name;
        m_desc = desc;
    }

    //Equipment
    public Item(int id, string name, int dmg, string desc, Recipe recp)
    {
        m_type = itemType.Equipment;
        m_id = id;
        m_icon = Resources.Load<Sprite>("ItemIcons/" + name);
        m_name = name;
        m_dmg = dmg;
        m_desc = desc;
        m_recp = recp;
    }

    //Consumble
    public Item(int id, string name, string desc, Recipe recp)
    {
        m_type = itemType.Consumable;
        m_id = id;
        m_icon = Resources.Load<Sprite>("ItemIcons/" + name);
        m_name = name;
        m_desc = desc;
        m_recp = recp;
    }

    //Default/Empty
    public Item()
    {
    }
}