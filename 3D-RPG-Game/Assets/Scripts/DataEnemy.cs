using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    [CreateAssetMenu(menuName = "ScriptableObject/DataEnemy" , fileName = "DataEnemy")]
    public class DataEnemy : ScriptableObject
    {
        [Range(0 , 2000)]
        public float hp;
        [Range(100 , 200)]
        public float attackPower;
        [Range(1 , 2)]
        public float attackRange;
        [Range(3 , 20)]
        public float detectRange;
        [Range(1 , 20)]
        public float moveSpeed;
        [Range(0 , 1)]
        public float dropRate;
        public GameObject loot;
        public Vector2 waitTimeRange;
        public LayerMask detectLayer;
        public float attackInterval;
    }
}
