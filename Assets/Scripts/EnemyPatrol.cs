using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public float waitTime = 1f;
    
    private int currentWaypoint = 0;
    private float waitCounter = 0f;
    private bool isWaiting = false;

    void Update()
    {
        if (waypoints.Length == 0) return;

        if (isWaiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                isWaiting = false;
            }
            return;
        }

        // Move towards current waypoint
        transform.position = Vector3.MoveTowards(
            transform.position,
            waypoints[currentWaypoint].position,
            moveSpeed * Time.deltaTime
        );

        // Check if reached waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            isWaiting = true;
            waitCounter = 0f;
        }
    }
}