using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : Combatant // Hérite de Combatant
{
    protected GameObject target; // La cible (allié)

    void Update()
    {
        target = FindNearestAlly();
        if (target != null)
        {
            MoveTowardsTarget(target);
        }
    }

    protected GameObject FindNearestAlly()
    {
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Ally");
        GameObject nearestAlly = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject ally in allies)
        {
            float distance = Vector3.Distance(transform.position, ally.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestAlly = ally;
            }
        }
        return nearestAlly;
    }


    protected void MoveTowardsTarget(GameObject target)
    {
        if (target == null || health <= 0) // Vérifie si le combattant est vivant
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);
    
        // Vérifie si l'ennemi peut attaquer ou doit se déplacer
        if (distance > attackRange) // Pour les combattants de mêlée
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Attack(target);
        }
    }


    protected abstract void Attack(GameObject target);
}
