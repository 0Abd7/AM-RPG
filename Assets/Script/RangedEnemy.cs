using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyAI
{
    public float attackCooldown = 1.5f; // Temps entre deux attaques
    private float lastAttackTime = 0f;

    void Update()
    {
        GameObject nearestAlly = FindNearestAlly();

        if (nearestAlly != null)
        {
            float distance = Vector3.Distance(transform.position, nearestAlly.transform.position);
            if (distance <= attackRange)
            {
                // Si le cooldown est écoulé, l'ennemi attaque
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    Attack(nearestAlly);
                    lastAttackTime = Time.time; // Met à jour le temps de la dernière attaque
                }
            }
            else
            {
                MoveTowardsTarget(nearestAlly); // Déplace vers l'allié le plus proche
            }
        }
        else
        {
            Debug.Log("No Allies Found");
        }
    }

    protected override void Attack(GameObject target)
    {
        // Infliger des dégâts à la cible
        if (target.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(10); // Inflige 10 dégâts
            Debug.Log($"{gameObject.name} attacked {target.name} for 10 damage."); // Affiche les dégâts infligés
        }
    }
}
