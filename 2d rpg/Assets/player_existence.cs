using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_existence : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
