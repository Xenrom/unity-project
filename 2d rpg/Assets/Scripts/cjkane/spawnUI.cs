using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawnUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dmg;
    public Transform target;

    void Start()
    {  
        GameObject dmgPrefab1 = Instantiate(dmg, new UnityEngine.Vector3(target.position.x, target.position.y, transform.position.z), UnityEngine.Quaternion.identity);
        TextMeshPro dmgPrefab2 = dmgPrefab1.GetComponent<TextMeshPro>();
        dmgPrefab2.text = "sex";
        Debug.Log(dmgPrefab2);

    }

    private IEnumerator segs(){
        float time = 0f;
        float duration = 5f;

        while (time < duration)
        {            
            time += 1f;
            Debug.Log(time);
            yield return new WaitForSeconds(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
