using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 30f;
    public float hitRadius;
    public int damage = 50;
    public ParticleSystem hitEffect;

    private void Start() 
    {
        if(hitEffect != null)
        {
            hitEffect.Play();
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            float distanceAtm = speed * Time.deltaTime;

            if (dir.magnitude <= distanceAtm)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceAtm, Space.World);
            transform.LookAt(target);
        }
    }

    void HitTarget()
    {
        if (hitRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        Destroy(gameObject);
        return;
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, hitRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hitRadius);
    }
}
