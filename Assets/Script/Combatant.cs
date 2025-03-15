using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combatant : MonoBehaviour
{
    public string combatantName;
    public float health;
    public float speed;
    public float attackRange;

    public virtual void TakeDamage(float amount) // Méthode pour infliger des dégâts
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    protected void Die() // Méthode pour gérer la mort
    {
        // Logique de mort (désactiver l'objet, etc.)
        gameObject.SetActive(false); // Exemple simple : désactiver l'objet
    }
}
