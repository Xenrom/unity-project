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
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

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
                GameObject.Destroy(gameObject);
            }
            
        }
    }


    private void waitForAnim()
    {
        Debug.Log("hello");
        GameObject.Destroy(gameObject);
      
    }

}
