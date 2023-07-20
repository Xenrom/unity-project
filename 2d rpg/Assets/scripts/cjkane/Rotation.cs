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
    public Transform fireTransform;
    public plrDmgReceive playerStat;
    public float cooldownTime;

    // Add the 'amount' variable and set its value as needed
    private float amount; // Adjust the amount of mana to decrease when firing Fireball

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        amount = 5f;
        cooldownTime = 0.35f;
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

        if (cooldownTime >= 0.35f && Input.GetMouseButtonDown(1) && playerStat.currentMana >= 5)
        {
            GameObject Fireball = Instantiate(FireRight, fireTransform.position, Quaternion.identity);
            Destroy(Fireball, 1.0f);
            playerStat.DecreaseMana(amount); // Use the 'amount' variable to decrease mana
            
            cooldownTime = 0f;
        }
    }
}
