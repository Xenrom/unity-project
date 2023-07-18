using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class existance : MonoBehaviour
{
    // Start is called before the first frame update
    DamageReceiver health;

    [Header("animation")]
    public float death_timer = 0;
    public Animator animator;
    public bool hasDeathAnimation=false;
    public string deathAnimationName;

    Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<DamageReceiver>();
    }
    // Update is called once per frame
    void Update()
    {
    
        if (animator != null) {
            
            if (health.currentHealth <= 0)
            {
                if (hasDeathAnimation)
                    animator.SetBool(deathAnimationName, true);

                if (death_timer <= 0)
                {
                    GameObject.Destroy(gameObject);
                    rb.Sleep();
                }
                else
                {
                    death_timer -= Time.deltaTime;
                }
            }
            
        }

    }
}
