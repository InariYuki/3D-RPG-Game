using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    [CreateAssetMenu(menuName = "ScriptableObject/DataHealth", fileName = "DataHealth")]
    public class DataHealth : ScriptableObject
    {
        public float HP;
        public float maxHP => HP;
        public bool canDropProp;
        public GameObject prop;
        public float dropRate;
    }
}
