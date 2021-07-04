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

        void Awake()
        {
            OnAttack();
        }
        void OnAttack()
        {
            timeBetweenAttacks = Random.Range(300, 600);
            timeOfNextAttack += timeBetweenAttacks;
        }

        void Attack()
        {
            GameObject newEnemy;
            int enemies = Random.Range(1, 10);
            for(int i = 1; i <= enemies; i++)
            {
                newEnemy = Instantiate(enemyPrefab);
                newEnemy.transform.position = this.transform.position;
                newEnemy.name.Replace("(Clone)", "");
            }
            OnAttack();
        }
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= timeOfNextAttack)
            {
                Attack();
            }
        }
    }
}