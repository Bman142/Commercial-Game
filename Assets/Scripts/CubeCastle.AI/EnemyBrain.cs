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
        List<GameObject> walls;

        void Awake()
        {
            walls = Managers.Manager.Instance.GetWalls();
            Target = walls[Random.Range(0, walls.Count)];
            agent.SetDestination(Target.transform.position);
            InvokeRepeating(nameof(AttackTimer), 0, 1f);
        }
        
        void AttackTimer()
		{
            
            Debug.Log(Vector3.Distance(Target.transform.position, this.transform.position));
            if (Vector3.Distance(Target.transform.position, this.transform.position) <= 10)
            {
                Attack();
            }
        }

        void Attack()
        {
            if (Target == null)
            {
                Target = walls[Random.Range(0, walls.Count)];
                agent.SetDestination(Target.transform.position);
            }
            else
            {
                Target.GetComponent<Defence.DefenceData>().TakeDamage(damage);
            }
        }

        public void TakeDamage(int damageTaken)
        {
            hp -= damageTaken;
            if (hp < 0) { hp = 0; }
            if (hp == 0) { Destroy(this.gameObject); }
        }
    }
}