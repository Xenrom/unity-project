using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class plrDmgReceive : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthText;
    public float maxHealth = 100f;
    public float currentHealth;
    private float hpMultiplier = 1f; // Initial multiplier value
    private float multiplierIncrement = 0.25f; // Amount to increase the multiplier each time

    private void Start()
    {
        LoadPlayerHealth(); // Load the player's health from PlayerPrefs
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float healthRatio = currentHealth / maxHealth;
        healthBar.value = healthRatio * 100f; // Multiply by 100 to convert the ratio to the 0-100 range
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

    public void IncreaseMaxHealth(float amount)
    {
        float increasedAmount = amount * hpMultiplier; // Multiply the base amount by the current multiplier value
        maxHealth += increasedAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        // Increase the multiplier for subsequent HP additions
        hpMultiplier += multiplierIncrement;
    }

    public void AddMaxHP()
    {
        float amountToAdd = 10f; // Define the base amount of max HP to add
        IncreaseMaxHealth(amountToAdd);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void SavePlayerHealth()
    {
        PlayerPrefs.SetFloat("MaxHealth", maxHealth);
        PlayerPrefs.SetFloat("CurrentHealth", currentHealth);
        PlayerPrefs.SetFloat("HPMultiplier", hpMultiplier);
        PlayerPrefs.Save();
    }

    public void LoadPlayerHealth()
    {
        if (PlayerPrefs.HasKey("MaxHealth"))
        {
            maxHealth = PlayerPrefs.GetFloat("MaxHealth");
            currentHealth = PlayerPrefs.GetFloat("MaxHealth"); // Set currentHealth equal to the saved maxHealth
            hpMultiplier = PlayerPrefs.GetFloat("HPMultiplier");
            UpdateHealthBar();
        }
    }

}
