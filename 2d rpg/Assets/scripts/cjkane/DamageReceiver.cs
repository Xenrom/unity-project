using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEditor;
using UnityEditor.Rendering;

#if Unity_Editor
using UnityEditor
#endif

public class DamageReceiver : MonoBehaviour
{
    [Header("stats")]
    public int maxHealth = 100;
    public float currentHealth;



    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }


}
