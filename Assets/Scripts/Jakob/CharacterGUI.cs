using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGUI : MonoBehaviour
{
    private UserStats stats;
    [SerializeField]
    private Text playerName;
    [SerializeField]
    private Text playerHp;
    [SerializeField]
    private GameObject panel;

    bool panelActive = false; 

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<UserStats>();
        UpdateTextfields();
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            panelActive = !panelActive;
            panel.SetActive(panelActive);

            UpdateTextfields();
        }
    }

    void UpdateTextfields()
    {
        playerName.text = stats.username + " Lv: " + stats.level.ToString();
        playerHp.text = "Hp: " + stats.maxHp.ToString();
    }

    public void Toggle()
    {
        Debug.Log("Hello World!");
        panelActive = !panelActive;
        panel.SetActive(panelActive);
    }
}
