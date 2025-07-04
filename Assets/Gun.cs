using System;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    private BoxCollider _gunTrigger;

    [Header("Range")]
    [SerializeField] private float m_range = 20f;
    [SerializeField] private float m_verticalRange = 20f;
    [SerializeField] private LayerMask m_layerMask;

    [Header("Stats")]
    [SerializeField] private float m_fireRate;
    [SerializeField] private int m_maxDamage;
    [SerializeField] private int m_minDamage;
    private float _nextTimeToFire;


    void Awake()
    {
        _gunTrigger = GetComponent<BoxCollider>();

        _gunTrigger.size = new Vector3(1, m_verticalRange, m_range);
        _gunTrigger.center = new Vector3(0, 0, m_range / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > _nextTimeToFire)
        {
            Fire();
        }
    }

    private void Fire()
    {
        //damage enemies
        _nextTimeToFire = Time.time + m_fireRate;

        //duplicate enemiesInTrigger to avoid modified collection problems
        List<IEnemy> enemiesToShoot = ServiceLocator.instance.GetService<EnemyManager>().enemiesInTrigger;
        foreach (var enemy in enemiesToShoot)
        {
            var dir = enemy.transform.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, m_range * 1.5f, m_layerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    //do less damage if they're far away.
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if (dist > m_range / 2)
                    {
                        enemy.GetShot(m_minDamage);
                    }
                    else
                    {
                        enemy.GetShot(m_maxDamage);
                    }
                    Debug.Log("Enemy got shot!");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        IEnemy enemyInRange = other.gameObject.GetComponent<IEnemy>();
        if (enemyInRange != null)
        {
            ServiceLocator.instance.GetService<EnemyManager>().AddEnemyToRange(enemyInRange);
        }
    }

    void OnTriggerExit(Collider other)
    {
        IEnemy enemyInRange = other.gameObject.GetComponent<IEnemy>();
        if (enemyInRange != null)
        {
            ServiceLocator.instance.GetService<EnemyManager>().RemoveEnemyToRange(enemyInRange);
        }
    }
    

}
