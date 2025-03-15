using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject meleePrefab;
    public GameObject rangedPrefab;

    public int numberOfAllies = 3;
    public int numberOfEnemies = 3;

    void Start()
    {
        // Générer les alliés
        for (int i = 0; i < numberOfAllies; i++)
        {
            GameObject ally = Instantiate(GetRandomCombatant(), GetRandomPosition(), Quaternion.identity);
            ally.tag = "Ally";
        }

        // Générer les ennemis
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemy = Instantiate(GetRandomCombatant(), GetRandomPosition(), Quaternion.identity);
            enemy.tag = "Enemy";
        }
    }

    GameObject GetRandomCombatant()
    {
        // Randomiser entre combattant de mêlée et à distance
        return Random.value > 0.5f ? meleePrefab : rangedPrefab;
    }

    Vector3 GetRandomPosition()
    {
        // Générer une position aléatoire sur la scène
        return new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }
}
