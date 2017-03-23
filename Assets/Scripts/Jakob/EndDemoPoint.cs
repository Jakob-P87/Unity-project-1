using UnityEngine;

public class EndDemoPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Paladin")
            Application.LoadLevel("EndGame");
    }
}
