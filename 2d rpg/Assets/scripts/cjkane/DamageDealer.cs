using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
     public int damageAmount = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();

                damageReceiver.TakeDamage(damageAmount);
                Debug.Log("Enemy has taken " + damageAmount + " damage.");

            Destroy(gameObject);
        }
    }
}
