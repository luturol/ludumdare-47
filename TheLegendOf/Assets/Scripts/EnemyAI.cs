using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;

    [SerializeField] float speed;

    [SerializeField] float nextWaypointDistance;
    [SerializeField] float stoppingDistance;
    [SerializeField] float retreatDistance;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seek;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        seek = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }

    void UpdatePath()
    {
        if (seek.IsDone() && target != null)
        {
            seek.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        if (target != null)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            //Faz o enemy voltar caso o player chegue muito perto e faz o enemy não chegar tão perto do player
            //e também move o enemy até o player
            float distanceBetweenPlayerAndEnemy = Vector2.Distance(rb.position, target.position);

            if (distanceBetweenPlayerAndEnemy > stoppingDistance)
            {
                rb.AddForce(force);
            }
            else if (distanceBetweenPlayerAndEnemy < retreatDistance)
            {
                force = direction * -speed * Time.deltaTime;
                rb.AddForce(force);
            }

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
    }
}
