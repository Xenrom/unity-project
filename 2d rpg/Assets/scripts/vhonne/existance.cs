using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class existance : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;

    float timer = 0.50f;
    public Animator animator;
    public AIPath aipath;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
 
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("health", health);
        if (health <= 0) {
            aipath.canMove = false;
            if (timer < 0)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                timer -= Time.deltaTime;
            }

            BoxCollider2D bc = GetComponent<BoxCollider2D>();
            bc.enabled = false;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.Sleep();
        }

    }
}
