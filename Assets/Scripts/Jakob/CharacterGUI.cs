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
    private Text playerVit;
    [SerializeField]
    private Text playerDex;
<<<<<<< HEAD
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
=======
>>>>>>> 877372159c6297e09d968a10eef6236129e37d98

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
<<<<<<< HEAD
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
=======
        playerHp.text = "Current Hp:    " + stats.maxHp.ToString();
        playerXp.text = "Current Exp:   " + stats.curXp.ToString();
        playerStr.text = "Str:          " + stats.curStrength.ToString();
        playerVit.text = "Vit:          " + stats.curVitality.ToString();
        playerDex.text = "Dex:          " + stats.curDexterity.ToString();
>>>>>>> 877372159c6297e09d968a10eef6236129e37d98
    }

    public void Toggle()
    {
        Debug.Log("Hello World!");
        panelActive = !panelActive;
        panel.SetActive(panelActive);
    }
}
