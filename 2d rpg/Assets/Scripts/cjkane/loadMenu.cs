using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMenu : MonoBehaviour
{
    public void load_Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void load_MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("mainMenu");
    }

    public void quit_Game()
    {
        Application.Quit();
    }
}
