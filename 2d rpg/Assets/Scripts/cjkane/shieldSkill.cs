using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldSkill : MonoBehaviour
{
    public GameObject shield;
    public GameObject shield2;
    public GameObject shield3;
    public plrDmgReceive statSystem;
    public float shieldAmount;
    public float cooldownTime;
    void Start()
    {
        shield.gameObject.SetActive(false);
        shieldAmount = 0;
        cooldownTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTime < 5f){
            cooldownTime += Time.deltaTime;
        }

        if (cooldownTime >= 5f && Input.GetMouseButtonDown(2)){
            Debug.Log("shit");

            shield.gameObject.SetActive(true);
            shield2.gameObject.SetActive(true);
            shield3.gameObject.SetActive(true);
            shieldAmount = 3f;
            
            cooldownTime = 0f;
        }
        if (shieldAmount > 0){
            statSystem.canDamage = false;
        }
        else{
            statSystem.canDamage = true;
        }
    }

    public void shieldLeftDown(){
        shield2.gameObject.SetActive(false);
    }
    public void shieldRightDown(){
        shield3.gameObject.SetActive(false);
    }
    public void shieldMainDown(){
        shield.gameObject.SetActive(false);
    }

    public void shieldDecrease(){
        shieldAmount -= 1f;
    }
}
