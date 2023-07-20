using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Rigidbody2D rb;

    float force = 5;
    float timeLimit = 2;

  


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = player.transform.position - transform.position;
        rb = GetComponent<Rigidbody2D>();
     
        
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLimit <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            timeLimit -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Destroy (gameObject);    
        }
    }

}
