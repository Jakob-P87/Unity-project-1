using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyUI : MonoBehaviour {

    public float maxHp;
    public float currentHp;
    public Slider hpSlider;
    Slider hp;
    public Canvas canvas;

    void Start ()
    {
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
                if (hit.collider == gameObject.GetComponent<Collider>())
                {
                    hp.gameObject.SetActive(true);
                }
                else if (hit.collider != gameObject.GetComponent<Collider>() || hit.collider.gameObject == null)
                {
                    hp.gameObject.SetActive(false);
                }
            }
        }
    }
    void OnDestroy()
    {
        Destroy(hp.gameObject);
    }
}