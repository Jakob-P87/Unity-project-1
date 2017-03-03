using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour {

    Vector2 pos;
    public Item[] actionBar = new Item[9];
    public Inventory inv;
    public ItemDatabase database;

    void Start ()
    {
        pos = new Vector2(Screen.width / 2 - 270, Screen.height - 120);
        for (int i = 0; i < actionBar.Length; i++)
        {
            actionBar[i] = new Item();
        }
	}
	
	void Update ()
    {
        for (int i = 0; i < inv.inventory.Count; i++)
        {
            if (inv.inventory[i].m_type == itemType.Consumable)
            {
                if (!ActionBarContains(inv.inventory[i].m_name))
                {
                    for (int j = 0; j < actionBar.Length; j++)
                    {
                        if(actionBar[j].m_name == null)
                        {
                            actionBar[j] = inv.inventory[i];
                            break;
                        }
                    }
                }
            }
        }
    }

    //void OnGUI()
    //{
    //    for (int x = 0; x < actionBar.Length; x++)
    //    {
    //        Rect slotRect = new Rect(60 * x + pos.x, 60 + pos.y, 50, 50);
    //        GUI.Box(slotRect, (x + 1).ToString());
    //        if (actionBar[x].m_name != null)
    //        { 
    //            GUI.DrawTexture(slotRect, actionBar[x].m_icon);
    //        }
    //    }
    //}

    bool ActionBarContains(string name)
    {
        for (int i = 0; i < actionBar.Length; i++)
        {
            if (name == actionBar[i].m_name)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(string name)
    {
        for (int i = 0; i < actionBar.Length; i++)
        {
            if (actionBar[i].m_name == name)
            {
                if (actionBar[i].m_stackSize < 1)
                {
                    actionBar[i] = new Item();
                }
                return;
            }
        }
    }
}
