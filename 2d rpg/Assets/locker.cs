using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locker : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.name);
    }
}
