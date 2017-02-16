using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float max_health = 100f;
    public float cur_health = 0f;
    public GameObject healthbar;


    // Use this for initialization
    void Start()
    {
        cur_health = max_health;
        InvokeRepeating("decreasehealth", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void decreasehealth()
    {
        cur_health -= 2f;
        float calc_health = cur_health / max_health; //calculates current health
        setHealthBar(calc_health);
    }

    public void setHealthBar(float myHealth)
    {
        //myHealth value 0-1
        healthbar.transform.localScale = new Vector3(myHealth, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }
}
