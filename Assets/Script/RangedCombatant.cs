using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCombatant : EnemyAI
{
    public float attackCooldown = 1.5f; // Délai entre chaque attaque à distance
    private float lastAttackTime;

    void Start()
    {
        lastAttackTime = -attackCooldown; // Pour pouvoir attaquer dès le début
    }

    void Update()
    {
        GameObject nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null && Vector3.Distance(transform.position, nearestEnemy.transform.position) <= attackRange)
        {
            Attack(nearestEnemy); // Passe le nearestEnemy comme argument
        }
        else
        {
            MoveTowards(nearestEnemy);
        }
    }

    protected override void Attack(GameObject target)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Logique d'attaque
            if (target.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(10); // Inflige des dégâts
                Debug.Log(gameObject.name + " attacked " + target.name);
            }

            // Met à jour le temps de la dernière attaque
            lastAttackTime = Time.time;
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }

    void MoveTowards(GameObject target)
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
