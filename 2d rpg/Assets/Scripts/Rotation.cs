using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Main
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject FireRight;
    public Transform fireTransform;
    private float timer;
    public float timeBetweenFire;
    private bool isAnimationCooldown;


    //Cursor
    public Texture2D clickCursorTexture;
    private Vector2 clickHotSpot = Vector2.zero;
    public Texture2D defaultCursorTexture;
    private Vector2 defaultHotSpot = Vector2.zero;


    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Combat targetScript = FindObjectOfType<Combat>();
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetMouseButtonDown(1) && !isAnimationCooldown){
            GameObject Fireball = Instantiate(FireRight, fireTransform.position, Quaternion.identity);
            Destroy (Fireball, 1.0f);
            isAnimationCooldown = true;
            Invoke("ResetAnimationCooldown", 0.35f);
        }
    }
    private void ResetAnimationCooldown()
    {
        isAnimationCooldown = false;
    }

}
