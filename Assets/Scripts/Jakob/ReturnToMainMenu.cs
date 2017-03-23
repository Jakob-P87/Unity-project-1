using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMainMenu : MonoBehaviour
{
	
    public void ReturnToMain()
    {
        Application.LoadLevel("MainMenu");
    }
}
