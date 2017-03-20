using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPointPlacing : MonoBehaviour
{

    public UserStats stats;


    public void StrStatPoint()
    {
        if (stats.statPoints > 0)
        {
            stats.curStrength += 1;
            stats.statPoints -= 1;
        }
        stats.UpdateStats();
    }
    public void VitStatPoint()
    {
        if (stats.statPoints > 0)
        {
            stats.curVitality += 1;
            stats.statPoints -= 1;
        }
        stats.UpdateStats();
    }
    public void DexStatPoint()
    {
        if (stats.statPoints > 0)
        {
            stats.curDexterity += 1;
            stats.statPoints -= 1;
        }
        stats.UpdateStats();
    }
}
