using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inventory : MonoBehaviour {

    public int slotsX, slotsY;
    public Vector2 pos;
    public ItemDatabase database;
    public string item;
    bool showInventory = false;

    // REAL Inventory
    public List<Item> inventory = new List<Item>();

    float distToPickup;

    int layerMask = ~(1 << 8);

    // Inventory graphical representation
    public List<InventorySlot> newInventory = new List<InventorySlot>();

    [SerializeField]
    GameObject InventorySlot;
    [SerializeField]
    GameObject InventoryUI;
    [SerializeField]
    GameObject InventorySlots;

    private void Start()
    {
        InventoryUI.SetActive(showInventory);

        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            inventory.Add(new Item());
            GameObject inventorySlot = Instantiate(InventorySlot, InventorySlots.transform);

            newInventory.Add(inventorySlot.GetComponent<InventorySlot>());
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            Toggle();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 999999, layerMask) && hit.collider.tag == "Pickup")
            {
                distToPickup = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, hit.transform.position);
                if (distToPickup <= 4.0f)
                {
                    AddItem(hit.collider.name);
                    DestroyObject(hit.transform.gameObject);
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Interactable")
            {
                distToPickup = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, hit.transform.position);
                if (distToPickup <= 6.0f)
                {
                    AddItem(hit.collider.GetComponent<pickup>().item);
                }
            }
        }
    }

    public void Toggle()
    {
        showInventory = !showInventory;
        InventoryUI.SetActive(showInventory);
        DrawInventory();
    }

    public void DrawInventory()
    {
        for (int i = 0; i < newInventory.Count; i++)
        {
            if (inventory[i].m_name != null)
            {
                newInventory[i].ItemIcon.enabled = true;
                newInventory[i].StackSize.enabled = true;
                newInventory[i].ItemIcon.sprite = inventory[i].m_icon;
                newInventory[i].StackSize.text = inventory[i].m_stackSize.ToString();
            }
            else
            {
                newInventory[i].ItemIcon.enabled = false;
                newInventory[i].StackSize.enabled = false;
            }
        }
    }

    public void AddItem(string name)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].m_name == name)
            {
                inventory[i].m_stackSize++;
                DrawInventory();
                break;
            }       
            else if(inventory[i].m_name == null && !ItemExist(name))
            {
                for (int j = 0; j < database.database.Count; j++)
                {
                    if (database.database[j].m_name == name)
                    {
                        inventory[i] = database.database[j];
                        inventory[i].m_stackSize = 1;
                        DrawInventory();
                    }
                }
                break;
            }                     
        }
    }

    public void RemoveItem(string name)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].m_name == name)
            {
                inventory[i].m_stackSize--;
                if (inventory[i].m_stackSize < 1)
                {
                    inventory[i] = new Item();
                }
                DrawInventory();
                return;
            }
        }
    }

    public bool ItemExist(string name)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (name == inventory[i].m_name)
            {
                return true;
            }
        }
        return false;
    }
}