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
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.1)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed; 
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex < WaypointsScript.waypoints.Length - 1)
        {
            wavepointIndex++;
            target = WaypointsScript.waypoints[wavepointIndex]; 
            

        } 
        else
        {
            // Destroy enemy and reduce player health by 5% when enemy has reached the end.
            Destroy(gameObject);
            PlayerStats.ReducePlayerHealth(0.05f);
        }
        
    }
}
