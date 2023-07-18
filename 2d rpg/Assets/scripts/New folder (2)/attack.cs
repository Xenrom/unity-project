using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

#if Unity_Editor
using UnityEditor
#endif

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    public GameObject player;
    public AIPath aipath;
    public plrDmgReceive healthBar;

    bool hitPlayer = false;
    Rigidbody2D rb;

    public bool hasAnimation = false;
    float timer = 0;
    Animator animator;
    string animationName = "attack";

    [CustomEditor(typeof(attack))]
    public class attackEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            attack Attack = (attack)target;

            if (Attack.hasAnimation)
            {
                EditorGUI.indentLevel++;

                Attack.animator = EditorGUILayout.ObjectField("animator", Attack.animator, typeof(Animator), true) as Animator;
                Attack.timer = EditorGUILayout.FloatField("time", Attack.timer);
                Attack.animationName = EditorGUILayout.TextField("name", Attack.animationName);

                EditorGUI.indentLevel--;
            }

        }
    }


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");  
        rb = gameObject.GetComponent<Rigidbody2D>();
        healthBar = FindObjectOfType<plrDmgReceive>();

        if (hasAnimation)
        {
            animator = GetComponentInChildren<Animator>();
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (hitPlayer)
        {
            if (timer > 0)
            {
                aipath.canMove = false;
                timer -= Time.deltaTime;
            }else if(timer <= 0)
            {
                hitPlayer = false;
                timer = 0.617f;
                
                aipath.canMove = true;
                healthBar.DecreaseHealth(damage);

                if(hasAnimation) animator.SetBool(animationName, false);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            hitPlayer = true;
            if (hasAnimation) animator.SetBool("attack", true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            hitPlayer = true;
            if (hasAnimation) animator.SetBool("attack", true);
        }
    }

    
}
