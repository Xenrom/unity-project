using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject FireRight;
    public Transform spawn;

    public float FireSpeed;

    Vector3 worldPosition;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
         mousePos.z = Camera.main.nearClipPlane;
         worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        if(Input.GetKeyDown(KeyCode.Space)){
             GameObject Fireball = Instantiate(FireRight, worldPosition, spawn.rotation);
             Rigidbody2D rigidbody2D = Fireball.GetComponent<Rigidbody2D>();

             rigidbody2D.velocity = FireSpeed * spawn.up;
     }
    }
}
