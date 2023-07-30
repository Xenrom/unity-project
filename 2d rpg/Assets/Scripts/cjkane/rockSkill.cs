using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class rockSkill : MonoBehaviour
{

    public GameObject rockAttack;
    public static bool isRock;

    // Update is called once per frame

    void Start(){
        isRock = false;
    }
    void Update()
    {
        Debug.Log(isRock);

        if (Input.GetKey(KeyCode.Z))
        {
            isRock = true;

            if (Input.GetMouseButtonDown(0)){
                GameObject rock = Instantiate(rockAttack, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);

                plrDmgReceive plrDmgReceive = transform.GetComponent<plrDmgReceive>();
                plrDmgReceive.DecreaseMana(1f);
                
                Destroy(rock, 0.5f);
            }
        }
        else
        {
            isRock = false;
        }

    }
}
