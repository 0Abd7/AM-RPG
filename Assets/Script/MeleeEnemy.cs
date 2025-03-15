using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyAI
{
    public float attackCooldown = 1.0f; // Temps entre deux attaques
    private float lastAttackTime = 0f;

    void Update()
    {
        GameObject nearestAlly = FindNearestAlly();

        if (nearestAlly != null)
        {
            float distance = Vector3.Distance(transform.position, nearestAlly.transform.position);
            if (distance <= attackRange)
            {
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    Attack(nearestAlly);
                    lastAttackTime = Time.time; // Met à jour le temps de la dernière attaque
                }
            }
            else
            {
                MoveTowardsTarget(nearestAlly);
            }
        }
        else
        {
            Debug.Log("No Allies Found");
        }
    }

    protected override void Attack(GameObject target)
    {
        if (target.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(10); // Inflige des dégâts
            Debug.Log($"{gameObject.name} attacked {target.name} for 10 damage."); // Affiche les dégâts infligés
        }
    }
}







