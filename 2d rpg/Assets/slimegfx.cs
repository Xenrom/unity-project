using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class slimegfx : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aipath;
    Rigidbody2D rb;
    [SerializeField] Vector2 velocity;

    void Awake()
    {
        aipath = GetComponentInParent<AIPath>();
        rb = GetComponentInParent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3 (-1f,1f, 1f);
        }else if(aipath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3 (1f, 1f, 1f);
        }
        velocity = rb.velocity;
    }
}
