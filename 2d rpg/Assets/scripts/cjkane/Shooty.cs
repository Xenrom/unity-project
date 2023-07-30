using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float timePassed;

    public float scale;
    public float force;
    
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot + 180);

        Debug.Log("started");
    }

    private void Update(){
        timePassed += Time.deltaTime;

        Debug.Log(Rotation.flameSize);

        if (timePassed >= 0.2f && !Rotation.isUp){
            transform.localScale = transform.localScale + new Vector3(scale, scale, scale);
            
            timePassed -= 0.2f;
        }

        if (Rotation.isUp){
            Animator animator = transform.GetComponent<Animator>();
            animator.SetBool("isFired", true);
        }
    }
}


