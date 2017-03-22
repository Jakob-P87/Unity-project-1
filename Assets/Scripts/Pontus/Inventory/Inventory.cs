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

    public List<Item> equipment = new List<Item>();

    float distToPickup;

    int layerMask = ~(1 << 8);

    // Inventory graphical representation
    public List<InventorySlot> newInventory = new List<InventorySlot>();

    public List<EquipmentSlot> newEquipmentSlots = new List<EquipmentSlot>();

    [SerializeField]
    GameObject InventorySlot;
    [SerializeField]
    GameObject InventoryUI;
    [SerializeField]
    GameObject InventorySlots;

    UserStats stats;

    private void Start()
    {
        InventoryUI.SetActive(showInventory);
        InventorySlot[] slots = InventorySlots.GetComponentsInChildren<InventorySlot>();
        EquipmentSlot[] equipSlots = InventoryUI.GetComponentsInChildren<EquipmentSlot>();

        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<UserStats>();

        for (int i = 0; i < slots.Length; i++)
        {
            newInventory.Add(slots[i]);
            slots[i].slotID = i;
        }

        for (int i = 0; i < equipSlots.Length; i++)
        {
            newEquipmentSlots.Add(equipSlots[i]);
            equipSlots[i].equipSlotID = i;
        }

        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            inventory.Add(new Item());
        }

        foreach (var slot in equipSlots)
        {
            equipment.Add(new Item());
        }
        AddItem("Iron Bar");
        AddItem("Wooden Log");
        AddItem("Leather");
        AddItem("Chain Mail");
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.B))
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
        DrawEquipment();
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

    public void DrawEquipment()
    {
        for (int i = 0; i < newEquipmentSlots.Count; i++)
        {
            if (equipment[i].m_name != null)
            {
                newEquipmentSlots[i].ItemIcon.enabled = true;
                newEquipmentSlots[i].ItemIcon.sprite = equipment[i].m_icon;
            }
            else
            {
                newEquipmentSlots[i].ItemIcon.enabled = false;                
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

    public void RemoveItem(string name, int nr = 1)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].m_name == name)
            {
                if (inventory[i].m_stackSize >= nr)
                {
                    inventory[i].m_stackSize -= nr;
                }
                if (inventory[i].m_stackSize < 1)
                {
                    inventory[i] = new Item();
                }
                DrawInventory();
                return;
            }
        }
    }
    
    public void AddEquipment(string name)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].m_name == name)
            {
                Item item = new Item(inventory[i]);
                item.m_stackSize = 1;

                if (item.m_equipType == EquipmentTypes.WEAPON)
                {
                    if (EquipmentExist(EquipmentTypes.WEAPON))
                    {
                        Item equippedItem = new Item(equipment[0]);
                        AddItem(equippedItem.m_name);
                    }
                    equipment[0] = item;
                    DrawEquipment();
                }
                else if (item.m_equipType == EquipmentTypes.SHIELD)
                {
                    if (EquipmentExist(EquipmentTypes.SHIELD))
                    {
                        Item equippedItem = new Item(equipment[1]);
                        AddItem(equippedItem.m_name);
                    }
                    equipment[1] = item;
                    DrawEquipment();
                }
                else if (item.m_equipType == EquipmentTypes.ARMOR)
                {
                    if (EquipmentExist(EquipmentTypes.ARMOR))
                    {
                        Item equippedItem = new Item(equipment[2]);
                        AddItem(equippedItem.m_name);
                    }
                    equipment[2] = item;
                    DrawEquipment();
                }
                RemoveItem(name);
            }
        }
        DrawEquipment();
        stats.UpdateStats();
    }

    public void RemoveEquipment(string name, int nr = 1)
    {
        for (int i = 0; i < equipment.Count; i++)
        {
            if (equipment[i].m_name == name)
            {
                if (equipment[i].m_stackSize >= nr)
                {
                    equipment[i].m_stackSize -= nr;
                }
                if (equipment[i].m_stackSize < 1)
                {
                    equipment[i] = new Item();
                }
                AddItem(name);
                DrawEquipment();
                stats.UpdateStats();
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

    public bool EquipmentExist(EquipmentTypes eType)
    {
        for (int i = 0; i < equipment.Count; i++)
        {
            if(equipment[i].m_equipType == eType)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasRecipe(Item item)
    {
        if (ItemExist(item.m_recp.m_mat1) && ItemExist(item.m_recp.m_mat2))
        {
            return true;
        }
        return false;
    }
}