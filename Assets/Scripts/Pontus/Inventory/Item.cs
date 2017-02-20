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
    public Texture2D m_icon;
    

    public Item(itemType type, int id, string name, int dmg, int def, string desc)
    {
        m_type = type;
        m_id = id;
        m_icon = Resources.Load<Texture2D>("ItemIcons/" + name);
        m_name = name;
        m_dmg = dmg;
        m_def = def;
        m_desc = desc;
    }

    public Item()
    {

    }
}
