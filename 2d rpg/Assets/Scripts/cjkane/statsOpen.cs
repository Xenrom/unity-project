using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsOpen : MonoBehaviour
{
        // StatUpgradeUI
    public Canvas canvas;
    public static bool isActive;

        // PauseMenuUI
    public Canvas pauseMenu;
    public bool isPaused = false;

    void Start(){
        canvas.enabled = false;
        pauseMenu.enabled = false;
    }

    void Update()
    {
        if (!isPaused){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isActive)
                {
                    ShowStats();
                    isActive = true;

                }
                else
                {
                    CloseStats();
                    isActive = false;
                }
            }
        }
        if (!plrDmgReceive.gameover)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    Debug.Log("Show pause");
                    ShowPauseMenu();
                }
                else
                {
                    Debug.Log("Close pause");
                    ClosePauseMenu();
                }
            }
        }
    }


    public void ShowStats(){
        canvas.enabled = true;
    }

    public void CloseStats(){
        canvas.enabled = false;
    }
    public void ShowPauseMenu(){
        pauseMenu.enabled = true;

        isPaused = true;
        Time.timeScale = 0f;
        plrDmgReceive.isPaused = true;
    }

    public void ClosePauseMenu(){
        pauseMenu.enabled = false;
        
        isPaused = false;
        Time.timeScale = 1f;
        plrDmgReceive.isPaused = false;
    }
}
