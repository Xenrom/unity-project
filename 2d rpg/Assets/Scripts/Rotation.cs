using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
       // Start is called before the first frame update
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject FireRight;
    public Transform fireTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFire;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire){
            timer += Time.deltaTime;
            if(timer > timeBetweenFire){
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && canFire){
            canFire = false;
            Instantiate(FireRight, fireTransform.position, Quaternion.identity);
        }
        
    }
}
