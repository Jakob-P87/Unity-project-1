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
    public int m_def;
    public Sprite m_icon;
    public int m_stackSize = 1;
    
    //public Item(Item other)
    //{
    //    m_type = other.m_type;
    //    m_id = other.m_id;
    //    m_icon = other.m_icon;
    //    m_name = other.m_name;
    //    m_dmg = other.m_dmg;
    //    m_def = other.m_def;
    //    m_desc = other.m_desc;
    //}

    public Item(itemType type, int id, string name, int dmg, int def, string desc)
    {
        m_type = type;
        m_id = id;
        m_icon = Resources.Load<Sprite>("ItemIcons/" + name);
        m_name = name;
        m_dmg = dmg;
        m_def = def;
        m_desc = desc;
    }

    public Item()
    {
    }
}
