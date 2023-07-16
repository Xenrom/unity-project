using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masochist : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       collision.gameObject.GetComponent<existance>().health -= damage * Time.deltaTime;
    }
}
