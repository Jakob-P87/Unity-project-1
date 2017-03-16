using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool showMenu;

    [SerializeField]
    GameObject PauseMenuUI;

    private void Start()
    {
        PauseMenuUI.SetActive(showMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu = !showMenu;
            PauseMenuUI.SetActive(showMenu);
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;
        }
    }

    public void Resume()
    {
        showMenu = !showMenu;
        PauseMenuUI.SetActive(showMenu);
        Time.timeScale = 1.0f;
    }

    public void exitGame()
    {
        Application.LoadLevel("MainMenu");
    }
}