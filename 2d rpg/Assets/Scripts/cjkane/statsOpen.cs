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
        if (!plrDmgReceive.gameover){
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    Debug.Log("Show pause");
                    ShowPauseMenu();
                    Time.timeScale = 0f;
                    isPaused = true;

                    plrDmgReceive.isPaused = true;
                }
                else
                {
                    Debug.Log("Close pause");
                    ClosePauseMenu();
                    Time.timeScale = 1f;
                    isPaused = false;

                    plrDmgReceive.isPaused = false;
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
    }

    public void ClosePauseMenu(){
        pauseMenu.enabled = false;
    }
}
