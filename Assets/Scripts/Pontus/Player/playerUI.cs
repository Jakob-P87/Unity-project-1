using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour {

    public UserStats stats;
    public Slider hpSlider;
    public Slider xpSlider;

    void Start ()
    {
        stats = GetComponent<UserStats>();
	}
	
	void Update ()
    {
        hpSlider.maxValue = stats.maxHp;
        hpSlider.value = stats.curHp;
        xpSlider.value = stats.curXp;
        xpSlider.maxValue = ((stats.level + 100) * stats.level + 13);
    }

    public void TakeDamage (float amount)
    {
        stats.curHp -= amount;
        if(stats.curHp < 0)
        {
            stats.curHp = 0;
        }
    }
}