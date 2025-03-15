using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 200; // Santé maximale
    private int currentHealth; // Santé actuelle

    void Start()
    {
        currentHealth = maxHealth; // Initialiser la santé actuelle
        Debug.Log($"{gameObject.name} starts with {currentHealth} health."); // Affiche la santé initiale
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0) return; // Ne pas appliquer des dégâts négatifs

        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took damage: {damage}. Current health: {currentHealth}.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} is dead!"); // Message de mort
        // Logique pour gérer la mort (par exemple, désactiver le personnage)
        gameObject.SetActive(false); // Désactive le GameObject (peut être remplacé par d'autres logiques)
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
