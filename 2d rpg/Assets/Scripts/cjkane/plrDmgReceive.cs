using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class plrDmgReceive : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthText;
    public float maxHealth = 100f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
        healthText.text = "Health: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0f)
        {
            Debug.Log("sex");
        }
    }
}