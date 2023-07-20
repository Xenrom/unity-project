using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class skillSystem : MonoBehaviour
{
    public Canvas skillSystemUI;
    public Rotation fireball;
    public Combat combat;
    public Slider combatBar;
    public Image cdDim;
    public TextMeshProUGUI cdText;

    void Start()
    {
        combatBar.gameObject.SetActive(false);
        cdDim.fillAmount = 0f;


    }

    // Update is called once per frame
    void Update()
    {   

            //  COMBAT

        if (combatBar.value != 0.35f){
            combatBar.gameObject.SetActive(true);
        }
        else{
            combatBar.gameObject.SetActive(false);
        }


        if (combat.cooldownTime >= 0.35f && combatBar.value != 0.35f){
            combatBar.value = 0.35f;
        }
        else {
            combatBar.value = combat.cooldownTime;
        }

        // FIREBALL

        if (fireball.cooldownTime >= 0.35f)
        {
            cdDim.fillAmount = 0f;
        }
        else
        {
            StartCoroutine(ContinuousFillAndDim());
        }
    }

    IEnumerator ContinuousFillAndDim()
    {
        cdDim.fillAmount = 1f;
        float timer = 0f;
        float cooldownDuration = 0.35f;

        while (timer < cooldownDuration)
        {
            timer += Time.deltaTime;
            cdDim.fillAmount = 1f - (timer / cooldownDuration);
            yield return null;
        }

        cdDim.fillAmount = 0f;
    }
}
