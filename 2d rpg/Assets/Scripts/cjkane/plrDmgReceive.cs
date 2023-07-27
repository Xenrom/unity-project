using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class plrDmgReceive : MonoBehaviour
{
        // HEALTH
    public Slider healthBar;
    public TextMeshProUGUI healthText;
    public float maxHealth = 100f;
    public float currentHealth;
    private float hpMultiplier = 1f; // Initial multiplier value
    private bool isHealthRegenAllowed;
    public float healthRegenAmount = 0.1f;
    private float regenTimer1;

        // MANA
    public Slider manaBar;
    public TextMeshProUGUI manaText;
    public float maxMana = 10f;
    public float currentMana;
    private float manaMultiplier = 1f; // Initial multiplier value
    private float regenTimer2;
    private bool isManaRegenAllowed;
    public float manaRegenAmount = 0.1f;

        // LEVEL/EXP
    private int currentLevel = 1; // Integer type for levels
    private int currentExp = 0;
    private int requiredExp = 25;
    private float expMultiplier = 1.5f;
    public Slider expBar;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public int statPoint = 0;
    public TextMeshProUGUI statPointText;

        // GLOBAL
    private float multiplierIncrement = 0.25f; // Amount to increase the multiplier each time
    public bool canDamage;
    public shieldSkill shield;
    public Transform player;
    public Transform respawnPoint;
    public Canvas gameOverUI;
    public float gameoverTimer;
    public static bool gameover;
    public static bool isPaused;
    public bool restarted = false;
    public TextMeshProUGUI clickLabel;
    public TextMeshProUGUI countText;
    public int enumTimer = 5;
    public float timeCount = 0f;


    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        UpdateHealthBar();
        UpdateManaBar();
        UpdateExpBar();
        UpdateStatPoint();

        isManaRegenAllowed = true;
        isHealthRegenAllowed = true;
        canDamage = true;
        gameOverUI.enabled = false;
        gameoverTimer = 0f;
        gameover = false;
        isPaused = false;
    }
    private void Update(){

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
                
                manaText.text = "Mana: " + currentMana.ToString("0.#") + "/" + maxMana.ToString("#.#");
            }
            else{
                manaText.text = "Mana: " + currentMana.ToString("0.#") + "/" + maxMana.ToString("#.#");
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
                
                healthText.text = "Health: " + currentHealth.ToString("0.#") + "/" + maxHealth.ToString("#.#");
            }
            else{
                healthText.text = "Health: " + currentHealth.ToString("0.#") + "/" + maxHealth.ToString("#.#");
            }
            regenTimer1 -= 0.5f;
        }

        if (isPaused){
            if (Input.GetMouseButtonDown(0)){
                clickLabel.enabled = false;
                countText.enabled = true;

                StartCoroutine(countdown(6f));
            }

            if (restarted){
                clickLabel.enabled = true;
                countText.enabled = true;
                gameOverUI.enabled = false;
                gameover = false;
                isPaused = false;
                restarted = false;
                Time.timeScale = 1f;
                enumTimer = 5;
                timeCount = 0f;

                player.transform.position = respawnPoint.transform.position;
                currentHealth = maxHealth;
                currentMana = maxMana;
                UpdateManaBar();
                UpdateHealthBar();
            }
        }
    }
    public void UpdateHealthBar()
    {
        float healthRatio = currentHealth / maxHealth; // Get the health ratio as a float
        healthBar.value = healthRatio * healthBar.maxValue; // Set the correct slider value
        healthText.text = "Health: " + currentHealth.ToString("0.#") + "/" + maxHealth.ToString("#.#");
    }
    public void UpdateManaBar()
    {
        float manaRatio = currentMana / maxMana; // Get the mana ratio as a float
        manaBar.value = manaRatio * manaBar.maxValue; // Set the correct slider value
        manaText.text = "Mana: " + currentMana.ToString("0.#") + "/" + maxMana.ToString("#.#");
    }
    public void UpdateExpBar(){
        float expRatio = (float)currentExp / requiredExp;
        expBar.value = expRatio * expBar.maxValue;
        expText.text = currentExp.ToString("0.#") + " / " + requiredExp.ToString("#.#");
        levelText.text = currentLevel.ToString("0.#");
    }
    public void UpdateStatPoint(){
        statPointText.text = statPoint.ToString();
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
            Time.timeScale = 0f;
            gameOverUI.enabled = true;
            countText.enabled = false;

            gameover = true;
            isPaused = true;
        }
    }
    public void DecreaseMana(float amount)
    {
        currentMana -= amount;
        currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
        UpdateManaBar();
    }
    public void DecreaseStatPoint(int amount){
        statPoint -= amount;
        UpdateStatPoint();
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
    public void IncreaseCurrentExp(int amount)
    {
        currentExp += amount;

        while (currentExp >= requiredExp)
        {
            LevelUp();
        }

        UpdateExpBar();
    }
    private void LevelUp()
    {
        currentLevel++; // Increase the level
        statPoint++;

        currentExp -= requiredExp; // Reset currentExp for next level
        requiredExp = Mathf.RoundToInt(requiredExp * expMultiplier);// Increase the required experience for the next level

        expBar.maxValue = requiredExp;
        UpdateStatPoint();
    }
    public void AddMaxHP()
    {
        if (statPoint > 0){
            float amountToAdd = 10f; // Define the base amount of max HP to add
            IncreaseMaxHealth(amountToAdd);
            EventSystem.current.SetSelectedGameObject(null);

            DecreaseStatPoint(1);
        }
    }
    public void AddMaxMana()
    {
        if (statPoint > 0){
            float amountToAdd = 2f; // Define the base amount of max mana to add
            IncreaseMaxMana(amountToAdd);
            EventSystem.current.SetSelectedGameObject(null);

            DecreaseStatPoint(1);
        }
    }
    
    
    private IEnumerator countdown(float amount){
        float duration = amount;

        while (timeCount < duration)
        {            
            timeCount += 1f;
            Debug.Log(timeCount);

            countText.text = enumTimer.ToString("0");
            enumTimer -= 1;

            yield return new WaitForSecondsRealtime(1f);
            if (timeCount >= duration){
                restarted = true;
            }
        }
    }

}
 