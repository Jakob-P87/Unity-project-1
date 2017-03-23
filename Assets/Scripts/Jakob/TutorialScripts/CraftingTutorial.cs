using UnityEngine;

public class CraftingTutorial : MonoBehaviour
{
    public GameObject childText;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Paladin")
        {
            childText.SetActive(true);
            Destroy(gameObject);
        }

    }
}
