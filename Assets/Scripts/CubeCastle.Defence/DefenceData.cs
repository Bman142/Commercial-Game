using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Defence
{
    public class DefenceData : MonoBehaviour
    { 
        [Tooltip("0 For Purely Defencive, any positive int for able to attack")]
        [SerializeField] int damage;
        [SerializeField] int hp;
        public int Damage { get { return damage; } }
        public int HP { set { hp -= value; } }

        public void TakeDamage(int amount)
        {
            hp -= amount;
            if(hp < 0) { hp = 0; }
            if(hp == 0) { Destroy(this.gameObject); }
        }

    }
}