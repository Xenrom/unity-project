using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEditor;
using UnityEditor.Rendering;
using TMPro;


#if Unity_Editor
using UnityEditor
#endif

public class DamageReceiver : MonoBehaviour
{
    

    [Header("stats")]
    public int maxHealth = 100;
    public float currentHealth;
    public GameObject damagePopUpUI;
    //animations
    public bool hasAnimation;
    [HideInInspector, SerializeField] Animator animator;
    [HideInInspector, SerializeField] string animationName;
    [HideInInspector, SerializeField] float animationTime;
    Rigidbody2D rigidbody2;
    
#if UNITY_EDITOR
    [CustomEditor(typeof(DamageReceiver))]
    public class DamageReceiverEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
                          
            DamageReceiver dr = (DamageReceiver)target;

            if (dr.hasAnimation)
            {
                dr.animator = EditorGUILayout.ObjectField(dr.animator, typeof(Animator), true) as Animator;


                dr.animationName = EditorGUILayout.TextField(dr.animationName);
                dr.animationTime = EditorGUILayout.FloatField("animationTime", dr.animationTime);
            }
      
        }
    }
#endif

    private void Start()
    {
        currentHealth = maxHealth;
        GameObject Player = GameObject.Find("Player");
    }

    public void TakeDamage(float damageAmount)
    {
        plrDmgReceive statSystem = FindObjectOfType<plrDmgReceive>();

        currentHealth -= damageAmount;
        damagePopUp(damageAmount);

        if (currentHealth <= 0)
        {
            if (hasAnimation)
            {
                animator.SetBool(animationName, true);
                rigidbody2.Sleep();
                Invoke("waitForAnim", animationTime);
            }
            else
            {
                statSystem.IncreaseCurrentExp(5);
                GameObject.Destroy(gameObject);
            }
            
        }
    }
    private void damagePopUp(float amount)
    {
        GameObject DmgUI = Instantiate(damagePopUpUI, new UnityEngine.Vector3(transform.position.x,
                                                        transform.position.y,
                                                        transform.position.z),
                                                        UnityEngine.Quaternion.identity);
        TextMeshPro damageText = DmgUI.GetComponent<TextMeshPro>();
        damageText.text = amount.ToString("0.#");
        Destroy(DmgUI, 0.3f);
    }


    private void waitForAnim()
    {
        Debug.Log("hello");
        GameObject.Destroy(gameObject);
      
    }

}
