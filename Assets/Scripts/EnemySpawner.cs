using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeCastle
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject enemyPrefab;
        float timer;
        float timeBetweenAttacks;
        float timeOfNextAttack;

        void OnAttack()
        {
            timeBetweenAttacks = Random.Range(300, 600);
            timeOfNextAttack += timeBetweenAttacks;
        }

    }
}