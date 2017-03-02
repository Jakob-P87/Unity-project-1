using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGUI : MonoBehaviour
{
    private UserStats stats;

    [SerializeField]
    private Text playerStr;
    [SerializeField]
    private Text strAmount;
    [SerializeField]
    private Text playerVit;
    [SerializeField]
    private Text vitAmount;
    [SerializeField]
    private Text playerDex;
    [SerializeField]
    private Text dexAmount;

    [SerializeField]
    private Text playerDmg;
    [SerializeField]
    private Text dmgAmount;
    [SerializeField]
    private Text playerAttackSpeed;
    [SerializeField]
    private Text atkSpd;

    [SerializeField]
    private Text playerName;
    [SerializeField]
    private Text playerHp;
    [SerializeField]
    private Text hpAmount;
    [SerializeField]
    private Text playerXp;
    [SerializeField]
    private Text xpAmount;

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
        playerHp.text = "Max Hp:";
        hpAmount.text = stats.maxHp.ToString();
        playerXp.text = "Exp:";
        xpAmount.text = stats.curXp.ToString();

        playerStr.text = "Str:";
        strAmount.text = stats.curStrength.ToString();
        playerVit.text = "Vit:";
        vitAmount.text = stats.curVitality.ToString();
        playerDex.text = "Dex:";
        dexAmount.text = stats.curDexterity.ToString();

        playerDmg.text = "Dmg";
        dmgAmount.text = stats.curAttackPower.ToString();
        playerAttackSpeed.text = "AtkSpd";
        atkSpd.text = stats.curAttackSpeed.ToString();
    }

    public void Toggle()
    {
        panelActive = !panelActive;
        panel.SetActive(panelActive);
    }
}
