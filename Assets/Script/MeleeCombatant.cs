using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombatant : EnemyAI
{
    public float attackCooldown = 0.0f; // Délai entre chaque attaque en secondes
    private float lastAttackTime;

    private Animator animator;

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

    void Start()
    {
        lastAttackTime = -attackCooldown; // Pour pouvoir attaquer dès le début
        animator = GetComponent<Animator>(); // Récupérer le composant Animator
    }

    protected override void Attack(GameObject target)
    {
        // Vérifie si assez de temps s'est écoulé depuis la dernière attaque
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Lancer l'animation d'attaque
            animator.SetTrigger("attack");

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
        if (target == null || health <= 0) // Vérifie si la cible et la santé sont valides
        {
            animator.SetBool("isRunning", false); // Passe en état Idle
            return; // Ne fait rien si la cible est invalide ou si le combattant est mort
        }

        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime; // Déplace le combattant vers la cible
        
        // Activer l'animation de course
        animator.SetBool("isRunning", true);
    }
}
