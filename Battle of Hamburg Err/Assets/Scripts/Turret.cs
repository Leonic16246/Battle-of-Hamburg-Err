using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;

    [Header("Attributes")]
    public float range = 10;

    [Header("Use Bullets (default)")]
    public float fireRate = 1;
    private float fireCountdown = 1;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30; 
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;

    [Header("Unity stuff")]
    public string enemyTag = "Enemy";

    public Transform headRotation;
    public float turnSpeed = 10;

    public GameObject pelletprefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>(); 
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
            }
            return;
        }

        // math for turret head rotation
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                FindObjectOfType<AudioManager>().Play("ShootSFX");
                Shoot();
                fireCountdown = 1 / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }

    }

    void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(headRotation.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        headRotation.rotation = Quaternion.Euler(0, rotation.y, 0);

    }

    void Laser()
    {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        impactEffect.transform.position = target.position;
    }

    void Shoot()
    {
        GameObject pelletGO = (GameObject)Instantiate(pelletprefab, firePoint.position, firePoint.rotation);
        Pellet pellet = pelletGO.GetComponent<Pellet>();

        if (pellet != null)
        {
            pellet.seek(target);
        }
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
