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
    private bool isHealthRegenAllowed;
    public float healthRegenAmount = 0.1f;
    private float regenTimer1;

    public Slider manaBar;
    public TextMeshProUGUI manaText;
    public float maxMana = 10f;
    public float currentMana;
    private float manaMultiplier = 1f; // Initial multiplier value
    private float regenTimer2;
    private bool isManaRegenAllowed;
    public float manaRegenAmount = 0.1f;

    private float multiplierIncrement = 0.25f; // Amount to increase the multiplier each time
    public bool canDamage;
    public shieldSkill shield;

    private void Start()
    {
        UpdateHealthBar();
        UpdateManaBar();

        isManaRegenAllowed = true;
        isHealthRegenAllowed = true;
        canDamage = true;
    }

    private void Update(){
        Debug.Log(canDamage);

        regenTimer1 += Time.deltaTime;
        regenTimer2 += Time.deltaTime;
        if (regenTimer2 >= 0.5f)
        {
            if (isManaRegenAllowed && currentMana < maxMana)
            {
                currentMana += manaRegenAmount; // Increase currentMana by the manaRegenAmount
                currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
                manaBar.value = currentMana;

                float manaRatio = currentMana / maxMana;
                manaBar.value = manaRatio * manaBar.maxValue;
                
                manaText.text = "Mana: " + currentMana.ToString("f1") + "/" + maxMana.ToString();
            }
            else{
                manaText.text = "Mana: " + currentMana.ToString() + "/" + maxMana.ToString();
            }
            regenTimer2 -= 0.5f;
        }
        if (regenTimer1 >= 0.5f)
        {
            if (isHealthRegenAllowed && currentHealth < maxHealth)
            {
                currentHealth += healthRegenAmount; // Increase currentMana by the manaRegenAmount
                currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
                healthBar.value = currentHealth;

                float healthRatio = currentHealth / maxHealth;
                healthBar.value = healthRatio * healthBar.maxValue;
                
                healthText.text = "Health: " + currentHealth.ToString("f1") + "/" + maxHealth.ToString();
            }
            else{
                healthText.text = "Health: " + currentHealth.ToString() + "/" + maxHealth.ToString();
            }
            regenTimer1 -= 0.5f;
        }

    }

    public void UpdateHealthBar()
    {
        float healthRatio = currentHealth / maxHealth; // Get the health ratio as a float
        healthBar.value = healthRatio * healthBar.maxValue; // Set the correct slider value
        healthText.text = "Health: " + currentHealth.ToString("f1") + "/" + maxHealth.ToString();
    }

    public void UpdateManaBar()
    {
        float manaRatio = currentMana / maxMana; // Get the mana ratio as a float
        manaBar.value = manaRatio * manaBar.maxValue; // Set the correct slider value
        manaText.text = "Mana: " + currentMana.ToString("f1") + "/" + maxMana.ToString();
    }
    public void DecreaseHealth(float amount)
    {
        if (canDamage == true){
            currentHealth -= amount;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            UpdateHealthBar();
        }

        shield.shieldDecrease();

        if (shield.shieldAmount == 2f){
            shield.shieldLeftDown();
        }
        if (shield.shieldAmount == 1f){
            shield.shieldRightDown();
        }
        if (shield.shieldAmount == 0f){
            shield.shieldMainDown();
        }

        if (currentHealth <= 0f)
        {
            Debug.Log("Player died.");
        }
    }
        public void DecreaseMana(float amount)
    {
        currentMana -= amount;
        currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
        UpdateManaBar();

        Debug.Log("e");
    }

    public void IncreaseMaxHealth(float amount)
    {
        float increasedAmount = amount * hpMultiplier; // Multiply the base amount by the current multiplier value
        maxHealth += increasedAmount;
        healthBar.maxValue = maxHealth;
        UpdateHealthBar();

        // Increase the multiplier for subsequent HP additions
        hpMultiplier += multiplierIncrement;
    }

    public void IncreaseMaxMana(float amount)
    {
        float increasedAmount = amount * manaMultiplier; // Multiply the base amount by the current multiplier value
        maxMana += increasedAmount;
        manaBar.maxValue = maxMana;
        UpdateManaBar();

        // Increase the multiplier for subsequent mana additions
        manaMultiplier += multiplierIncrement;
    }

    public void AddMaxHP()
    {
        float amountToAdd = 10f; // Define the base amount of max HP to add
        IncreaseMaxHealth(amountToAdd);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void AddMaxMana()
    {
        float amountToAdd = 2f; // Define the base amount of max mana to add
        IncreaseMaxMana(amountToAdd);
        EventSystem.current.SetSelectedGameObject(null);
    }


}
 