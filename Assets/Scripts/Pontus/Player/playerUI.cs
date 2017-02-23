using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour {

    public UserStats stats;
    public LevelSystem level;
    public Slider hpSlider;
    public Slider xpSlider;

    void Start ()
    {
        stats = GetComponent<UserStats>();
        level = GetComponent<LevelSystem>();
	}
	
	void Update ()
    {
        hpSlider.value = stats.curHp;
        xpSlider.value = level.currentExp;
        xpSlider.maxValue = ((level.level + 100) * level.level + 13);
    }

    public void TakeDamage (int amount)
    {
        stats.curHp -= amount;
        if(stats.curHp < 0)
        {
            stats.curHp = 0;
        }
    }
}