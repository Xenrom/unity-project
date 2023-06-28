using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject FireRight;
    public Transform spawn;

    public float FireForce = 20f;



    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Space)){
             GameObject Fireball = Instantiate(FireRight, spawn.position, spawn.rotation);
             Rigidbody2D rigidbody2D = Fireball.GetComponent<Rigidbody2D>();

             rigidbody2D.AddForce(spawn.up * FireForce, ForceMode2D.Impulse);
     }
    }
}
