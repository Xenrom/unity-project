using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgPlayer : MonoBehaviour
{
    public float damageAmount = 1f;
    public float damageCooldown = 1f;
    public plrDmgReceive healthBar;

    private float lastDamageTime;
    public shieldSkill shield;

    private void Start()
    {
        healthBar = FindObjectOfType<plrDmgReceive>();
        lastDamageTime = -damageCooldown;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("Hit"); //check

            if (Time.time >= lastDamageTime + damageCooldown)
            {
                if (healthBar != null)
                {
                    healthBar.DecreaseHealth(damageAmount);
                }

                lastDamageTime = Time.time;
            }
        }
    }
}
