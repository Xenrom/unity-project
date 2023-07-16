using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemypreFab;
    float time = 0;
    float spawnrate = 2;
    int spawnLimit = 5;
    [SerializeField] GameObject[] enemy;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        if (time < spawnrate)
        {
            time = time + Time.deltaTime;
        }
        else
        {
            
           if(enemy.Length < spawnLimit)
            {
                create();
                time = 0;
                print(enemy.Length);
            }
           else if (enemy.Length >= spawnLimit)
            {
                time = 0;
            }
        
        } 
    }

    void create()
    {

        float posy = Random.Range(transform.position.y - 4, transform.position.y + 4);
        float posx = Random.Range(transform.position.x - 4, transform.position.x + 4);
        Vector3 enemyPos = new Vector2(posx, posy);
        foreach (GameObject obj in enemy)
        {
            if(obj.transform.position == enemyPos)
            {
                posy = Random.Range(transform.position.y - 4, transform.position.y + 4);
                posx = Random.Range(transform.position.x - 4, transform.position.x + 4);
                enemyPos = new Vector2(posx, posy);
            }
        }

        Instantiate(enemypreFab, enemyPos, transform.rotation);
    }
}
