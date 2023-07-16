using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    // Start is called before the first frame update
    public float damagePoint;
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
           if (collision.gameObject == player)
        {
            //damage
            GameObject.Destroy(gameObject);
        }
    }
}
