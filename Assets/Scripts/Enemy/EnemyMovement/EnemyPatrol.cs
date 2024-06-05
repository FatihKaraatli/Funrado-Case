using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour , IEnemyPatrol
{
    [Header("Way Point Transforms")]
    public Transform[] waypoints;

    [Header("Speed")]
    public float speed = 2f;
    public float rotationSpeed = 2f;

    [Header("RotateObject")]
    public Transform enemy;
    public Transform visionCone;

    [Header("Static Or Movable Choose")]
    public bool shouldStopPatroling = false;

    private int currentWaypoint = 0;
    
    void Update()
    {
        if (!shouldStopPatroling)
        {
            Patrol();
        }
    }

    public void Patrol()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        Transform target = waypoints[currentWaypoint];
        Vector3 direction = transform.position - target.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        
        if (Mathf.Abs(Vector3.Distance(target.position , transform.position)) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

        this.gameObject.GetComponent<EnemyAnimation>().WalkAnimation();

        ConvertDirectionToYRotation(-1 * direction);
    }

    public void ConvertDirectionToYRotation(Vector3 dir)
    {
        Vector3 direction = Vector3.RotateTowards(enemy.forward, dir, rotationSpeed * Time.deltaTime, 0.0f);
        enemy.rotation = Quaternion.LookRotation(direction);
        visionCone.rotation = Quaternion.LookRotation(direction);
        
    }

    public void SetPatrol()
    {
        shouldStopPatroling = true;
    }


}
