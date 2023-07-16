using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    float force = 10;
    GameObject player;

    public float timeLimit = 2;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    
    
    }
    void Update()
    {
       if(timeLimit <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            timeLimit -= Time.deltaTime;
        }
    }
}
