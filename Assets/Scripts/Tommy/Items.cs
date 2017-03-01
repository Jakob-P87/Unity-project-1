using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items {
    public List<UserStats> Stats { get; set; }
    public string ObjectSlug { get; set; }

    public Items(List<UserStats> _Stats, string _ObjectSlug)
    {
        this.Stats = _Stats;
        this.ObjectSlug = _ObjectSlug;
    }

}
