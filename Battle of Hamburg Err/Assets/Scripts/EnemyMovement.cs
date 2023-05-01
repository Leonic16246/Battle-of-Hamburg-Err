using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 20;
    private Transform target;
    private int wavepointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = WaypointsScript.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.1)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex < WaypointsScript.waypoints.Length - 1)
        {
            wavepointIndex++;
            target = WaypointsScript.waypoints[wavepointIndex]; 
            

        } else
        {
            Destroy(gameObject);
            
        }
        
    }
}
