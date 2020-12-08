using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargetSystem : MonoBehaviour
{
    private Transform target;
    private Enemy enemy;
    public float range = 3f;
    public string enemyTag = "Enemy";
    public float fireRate = 1f;
    private float fireDelay = 0f;

    public bool useLaser = false;
    public int damageOverTime = 5;
    public LineRenderer lineRenderer;

    public ParticleSystem hitEffect;
    public AudioSource hitSound;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0.1f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireDelay <= 0)
            {
                Shoot();
                fireDelay = 1f / fireRate;
                hitSound.Play();
                if(hitEffect != null)
                {
                    hitEffect.Play();
                }
            }

            fireDelay -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(direction);
        Vector3 rotate = lookAt.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotate.y, 0f);
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
            enemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void Shoot()
    {
        GameObject bulletBasic = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletBasic.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }


    void Laser()
    {
        enemy.TakeDamage(damageOverTime * Time.deltaTime);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            hitSound.Play();
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

}
