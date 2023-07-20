using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsOpen : MonoBehaviour
{
    public Canvas canvas;
    public bool isActive;

    void Start(){
        canvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isActive)
            {
                Debug.Log("Show Stats");
                ShowStats();
                Time.timeScale = 0f;
                isActive = true;
            }
            else
            {
                Debug.Log("Close Stats");
                CloseStats();
                Time.timeScale = 1f;
                isActive = false;
            }
        }
    }


    public void ShowStats(){
        canvas.enabled = true;
    }

    public void CloseStats(){
        canvas.enabled = false;
    }
}
