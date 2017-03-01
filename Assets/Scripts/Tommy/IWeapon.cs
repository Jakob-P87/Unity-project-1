using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {
    List<UserStats> Stats { get; set; }
    void PerformAttack();
}
