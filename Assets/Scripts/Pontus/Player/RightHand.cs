using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour {

    Inventory inv;
    GameObject go;
    bool equipped = false;

    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

	void Update()
    {
        if (inv.EquipmentExist(EquipmentTypes.WEAPON) && !equipped)
        {
            StartCoroutine(AddWeapon());
        }

        if (!inv.EquipmentExist(EquipmentTypes.WEAPON) && equipped)
        {
            StartCoroutine(RemoveWeapon());
        }

        if (equipped)
        {
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
        }

    }

    IEnumerator AddWeapon()
    {
        go = (GameObject)Instantiate(Resources.Load("Prefabs/Iron Sword"), transform.position, transform.rotation);
        go.transform.localScale = new Vector3(18f, 18f, 18f);
        equipped = true;
        yield break;
    }
    IEnumerator RemoveWeapon()
    {
        Destroy(go);
        equipped = false;
        yield break;
    }
}