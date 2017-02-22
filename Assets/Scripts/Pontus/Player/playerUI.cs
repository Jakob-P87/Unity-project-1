using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour {

    public UserStats stats;
    public Slider hpSlider;

    void Start ()
    {
        stats = GetComponent<UserStats>();
	}
	
	void Update ()
    {
        hpSlider.value = stats.curHp;
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