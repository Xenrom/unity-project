using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class addThings : MonoBehaviour
{
    public float chunkSize;
    public int maxSpawneePerChunk;
    public GameObject[] things;
    private void Start()
    {

        int numberOfSpawnee = Random.Range(0, maxSpawneePerChunk);
        float right = transform.position.x + (chunkSize/2);
        float left = transform.position.x - (chunkSize / 2);
        float bottom = transform.position.y - (chunkSize / 2);
        float top = transform.position.y + (chunkSize / 2);
        for (int i = 0; i < numberOfSpawnee; i++)
        {
            int randomSpawn = Random.Range(0, things.Length);
            Vector2 pos = new Vector2(Random.Range(left, right), Random.Range(bottom, top));

            GameObject newThing = Instantiate(things[randomSpawn], (Vector3)pos, Quaternion.identity);
            newThing.transform.parent = transform;
        }
    }
}
