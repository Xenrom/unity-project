using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamekaze : MonoBehaviour
{
    // Start is called before the first frame update
    public DamageReceiver damageReceiver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damageReceiver.TakeDamage(100);

        }
    }
}
