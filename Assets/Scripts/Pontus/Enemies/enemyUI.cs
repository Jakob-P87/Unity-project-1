using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyUI : MonoBehaviour {

    public float maxHp;
    public float currentHp;
    public Slider hpSlider;
    public Slider hp;
    private Canvas canvas;

    void Start ()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        hp = (Slider)Instantiate(hpSlider);
        hp.transform.SetParent(canvas.transform, false);
        hp.maxValue = maxHp;
        hp.value = currentHp;
        hp.gameObject.SetActive(false);
    }

	void Update ()
    {
        hp.value = currentHp;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == gameObject.GetComponent<Collider>()) //if gameObject is clicked on
                {
                    hp.gameObject.SetActive(true); //activates gameObjects slider
                }
                else if (hit.collider != gameObject.GetComponent<Collider>() || hit.collider.gameObject == null) //if gameObject isn't clicked on
                {
                    hp.gameObject.SetActive(false); //deactivates gameObjects slider
                }
            }
        }
    }
}