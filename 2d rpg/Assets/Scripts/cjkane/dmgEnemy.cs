using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgEnemy : MonoBehaviour
{
     public int damageAmount = 50;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("enemy"))
        {
            DamageReceiver damageReceiver = collision.gameObject.GetComponent<DamageReceiver>();

                damageReceiver.TakeDamage(damageAmount);
                Debug.Log("Enemy has taken " + damageAmount + " damage.");

            Destroy(gameObject);
        }
    }
}
