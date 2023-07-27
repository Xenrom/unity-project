using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgUIAnim : MonoBehaviour
{

    public float timePassed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro text = transform.GetComponent<TextMeshPro>();
        Color textColor = text.color;

        float moveSpeed = 20f;
        timePassed += Time.deltaTime;

        if (timePassed >= 0.025f){
            transform.position += new Vector3(0, moveSpeed) * Time.deltaTime;
            textColor.a -= 0.1f;
            text.color =  textColor;

            timePassed -= 0.025f;
        }
    }
}
