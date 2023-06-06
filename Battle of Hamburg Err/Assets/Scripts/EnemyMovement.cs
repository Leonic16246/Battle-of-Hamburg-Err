using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy; 

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>(); 
        target = WaypointsScript.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction from the current position to the target position
        Vector3 direction = target.position - transform.position;

        // Move the enemy towards the target position at a speed determined by enemy.speed
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        // Check if the enemy has reached the target position with a small tolerance of 0.1 units
        if (Vector3.Distance(transform.position, target.position) < 0.1)
        {
            // If the enemy has reached the target position, get the next waypoint
            GetNextWaypoint();
        }

        // Reset the enemy's speed to its initial startSpeed if needed
        //enemy.speed = Enemy.startSpeed; 
    }

    void GetNextWaypoint()
    {
        // Check if there are more waypoints available in the array
        if (wavepointIndex < WaypointsScript.waypoints.Length - 1)
        {
            // Increment the wavepointIndex to move to the next waypoint
            wavepointIndex++;
            // Set the target to the next waypoint in the waypoints array
            target = WaypointsScript.waypoints[wavepointIndex]; 
        } 
        else
        {
            // Destroy enemy and reduce player health by 5% when enemy has reached the end.
            WaveSpawner.EnemiesAlive--; 
            Destroy(gameObject);
            PlayerStats.instance.ReducePlayerHealth(enemy.damage);
        }
        
    }
}
