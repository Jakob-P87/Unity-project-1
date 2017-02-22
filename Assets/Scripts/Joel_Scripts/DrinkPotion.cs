using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkPotion : MonoBehaviour {

    public Inventory inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var Player = this.GetComponent<UserStats>();

            if (inventory.ItemExist("Health Potion"))
            {
                inventory.RemoveItem("Health Potion");
                Player.curHp = Player.maxHp;

            }
        }
    }

}
