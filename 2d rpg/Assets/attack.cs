using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    public GameObject player;
    public Animator animator;
    public AIPath aipath;

    [SerializeField] float playerHealth;

    float timer = .617f;
    bool hitPlayer = false;

    Rigidbody2D rb;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponentInChildren<Animator>();    
        rb = gameObject.GetComponent<Rigidbody2D>();    
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
                animator.SetBool("attack", false);
                aipath.canMove = true;
                
                player.GetComponent<player_existence>().health -= damage * Time.deltaTime;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            hitPlayer = true;
            animator.SetBool("attack", true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            hitPlayer = true;
            animator.SetBool("attack", true);
        }
    }

    
}
