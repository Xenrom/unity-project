using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    private float startTime;
    public float scaleDuration = 3.0f; // Total duration for the scaling effect

    private float damageIncreaseTimer = 0.0f;
    private float damageIncreaseInterval = 0.1f;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);

        startTime = Time.time; // Record the start time
        Debug.Log("started");
        dmgEnemy.damageAmount = 30;
    }

    private void Update()
    {   
            damageIncreaseTimer += Time.deltaTime;
        if (damageIncreaseTimer >= damageIncreaseInterval)
        {
            dmgEnemy.damageAmount += 3;
            damageIncreaseTimer = 0.0f; // Reset the timer
        }
        float elapsedTime = Time.time - startTime;
        
        // Calculate the scaling factor based on time
        float scaleFactor = Mathf.Lerp(1.0f, 2.0f, elapsedTime / scaleDuration);
        
        // Apply the scaling
        transform.localScale = Vector3.one * scaleFactor;
    }
}
