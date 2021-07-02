using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Defence
{
    public class DefenceData : MonoBehaviour
    { 
        int damage;
        int hp;
        public int Damage { get { return damage; } }
        public int HP { set { hp -= value; } }


    }
}