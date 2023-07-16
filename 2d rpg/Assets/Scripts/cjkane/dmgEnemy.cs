using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgEnemy : MonoBehaviour
{
     public int damageAmount = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("enemy"))
        {
            DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();

                damageReceiver.TakeDamage(damageAmount);
                Debug.Log("Enemy has taken " + damageAmount + " damage.");
            Debug.Log(other.name);

            Destroy(gameObject);
        }
    }
}
