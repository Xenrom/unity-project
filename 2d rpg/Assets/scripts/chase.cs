using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class chase : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidBody;
    public int moveSpeed;
    public GameObject player;
    private Transform playerPos;
    private Vector2 CurrentPos;
    public float distance;
    public GameObject spawner;
    Vector3 spawnerPos;
    bool rtrn = false;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.Find("spawner");
        CurrentPos = GetComponent<Transform>().position;
        spawnerPos = spawner.transform.position;
    }
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
        }
       else
        {
            if (Vector2.Distance(transform.position, spawnerPos) >= 4)
            {
                rtrn = true;
            }
            if (rtrn == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, CurrentPos, moveSpeed * Time.deltaTime);
            }
            if(Vector2.Distance(transform.position, CurrentPos) == 0)
            {
                rtrn= false;
            }
            
        }

    }



}
