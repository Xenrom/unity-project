using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public GameObject damageAreaPrefab;
    public float damageCooldown = 1;
    public bool isDamaging = false;
    public GameObject damagePoint;

    // Update is called once per frame
    void Update()
    {
        // Calculate the angle between the player and the mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = transform.position;
        Vector2 direction = mousePosition - playerPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0) && !isDamaging)
        {
            GameObject damageArea = Instantiate(damageAreaPrefab, damagePoint.transform.position, Quaternion.Euler(0, 0, angle));
            Destroy(damageArea, damageCooldown);
            isDamaging = true;
            Invoke("StartDamageCooldown", damageCooldown);
        }
    }
    
    private void StartDamageCooldown()
    {
        isDamaging = false;
    }
}
