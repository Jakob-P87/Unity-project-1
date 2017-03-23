using UnityEngine;
using UnityEngine.UI;

public class TutorialTextDestroyer : MonoBehaviour
{
    private Text tutorialText;

    void Start()
    {
        tutorialText = GetComponent<Text>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            Destroy(tutorialText);
    }
}
