using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject spawnee;
    public List<GameObject> enemies;

    [Header("spawner customable")]
    public string spawnerName;
    public int maxEnemy = 5;
    public float interval = 2;

    float timer = 0;
    

    private void Update()
    {

        if (enemies.Count < maxEnemy)
        {
            if (timer >= interval)
            {
                create();
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }      
    }

   private void create()
    {
        float xPosLeft = transform.position.x - (transform.localScale.x / 2);
        float xPosRight = transform.position.x + (transform.localScale.x / 2);

        float yPosLeft =  transform.position.y - (transform.localScale.y / 2);
        float yPosRight = transform.position.y + (transform.localScale.y / 2);

        GameObject newEnemy = Instantiate(spawnee, new Vector3(Random.Range(xPosLeft, xPosRight), Random.Range(yPosLeft, yPosRight), 0), Quaternion.identity);
        enemies.Add(newEnemy);
        
    }
}
