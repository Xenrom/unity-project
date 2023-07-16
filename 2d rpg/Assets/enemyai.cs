using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemyai : MonoBehaviour
{
    [Header("Pathfinder")]
    public Transform target;
    public float nextWayPointDistance = 3f;

    [Header("physics")]
    public float speed = 200f;

    [Header("custom")]
    public float pathDistanceFollow = 200f;
    public bool follow=false;

    Path path;
    int currentWayPoint = 0;
    bool reachEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("updatePath", 0f, .5f);
        
    }

    private void updatePath()
    {
        if(seeker.IsDone() && follow && TargetinDistance())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(TargetinDistance() && follow)
        {
            Pathfollow();
        }
    }

    void Pathfollow()
    {
        if (path == null)
            return;

        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;
        }
        else
        {
            reachEndOfPath=false;
        }
        
        Vector2 Direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = Direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance( rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }

    private bool TargetinDistance()
    {
        return Vector2.Distance(rb.position, target.position) < pathDistanceFollow;
    }
}
