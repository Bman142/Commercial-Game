using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//TODO: Code Refactor
namespace CubeCastle.AI
{
    public class EnemyBrain : MonoBehaviour
    {
        GameObject Target;
        [SerializeField] NavMeshAgent agent;
        [SerializeField] int damage;
        [SerializeField] int hp;

        float timeBetweenAttacks = 2f;
        float timeofNextAttack;
        float timer;
        void Awake()
        {
            List<GameObject> walls = Managers.Manager.Instance.GetWalls();
            Target = walls[Random.Range(0, walls.Count)];
            agent.SetDestination(Target.transform.position);
        }
        void Update()
        {
            timer += Time.deltaTime;
            if(Vector3.Distance(Target.transform.position, this.transform.position) <= 1)
            {
                if(timer >= timeofNextAttack)
                {
                    Attack();
                    timeofNextAttack += timeBetweenAttacks;

                }
                
            }
        }

        void Attack()
        {
            Target.GetComponent<Defence.DefenceData>().TakeDamage(damage);
        }

        public void TakeDamage(int damageTaken)
        {
            hp -= damageTaken;
            if (hp < 0) { hp = 0; }
            if (hp == 0) { Destroy(this.gameObject); }
        }
    }
}