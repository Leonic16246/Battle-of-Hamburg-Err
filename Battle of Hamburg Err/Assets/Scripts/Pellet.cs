using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{

    private Transform target;
    public float speed = 50;
    public GameObject impactParticle;

    public void seek(Transform _target)
    {
        target = _target;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject particle = (GameObject)Instantiate(impactParticle, transform.position, transform.rotation);
        Destroy(particle, 2);

        Destroy(target.gameObject);
        PlayerStats.Money += 10;

        Destroy(gameObject);
    }

}
