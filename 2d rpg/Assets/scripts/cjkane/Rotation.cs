using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject FireRight;
    public GameObject Prfb_Flame;
    public static bool isFlame;
    public Transform fireTransform;
    public plrDmgReceive playerStat;
    public float cooldownTime;

    public static float flameSize;
    public static float flameSpeed;
    public static bool isUp;

    // Add the 'amount' variable and set its value as needed
    private float amount; // Adjust the amount of mana to decrease when firing Fireball

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        amount = 5f;
        cooldownTime = 0.35f;
        isFlame = false;
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        
        if (cooldownTime < 0.35f){
            cooldownTime += Time.deltaTime;
        }
        if (!plrDmgReceive.isPaused){
            if (cooldownTime >= 0.35f && Input.GetKey(KeyCode.F) && playerStat.currentMana >= 5)
            {
                GameObject Fireball = Instantiate(FireRight, fireTransform.position, Quaternion.identity);
                Destroy(Fireball, 5.0f);
                playerStat.DecreaseMana(amount); // Use the 'amount' variable to decrease mana
                
                cooldownTime = 0f;
            }
        }
        if (Input.GetKey(KeyCode.X)){
            isFlame = true;

            if (Input.GetMouseButtonDown(0)){
                GameObject Flame = Instantiate(Prfb_Flame, fireTransform.position, Quaternion.identity);
            }
        }
        else
        {
            isFlame = false;
        }




        //REVAMP

        if(!plrDmgReceive.isPaused)
        {
            if(Input.GetMouseButtonDown(1)){
                GameObject flame = Instantiate(Prfb_Flame, fireTransform.position, Quaternion.identity);

                isUp = false;
            }
            if(Input.GetMouseButton(1))
            {

                Debug.Log("Key is down");

                if(Input.GetAxis("Mouse ScrollWheel") != 0f)
                {
                    flameSpeed += Input.GetAxis("Mouse ScrollWheel");

                    Debug.Log(flameSpeed);
                }
            }
            if(Input.GetMouseButtonUp(1)){
                isUp = true;

                Debug.Log("is up");
            }
        }
    }
}
