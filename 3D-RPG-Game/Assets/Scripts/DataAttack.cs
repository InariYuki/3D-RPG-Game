using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    [CreateAssetMenu(menuName = "ScriptableObject/DataAttack" , fileName = "DataAttack")]
    public class DataAttack : ScriptableObject
    {
        public float attack;
        public Color attColor;
        public Vector3 attArea , offset;
        public LayerMask playerLayer;
        public float attDelay;
        public AnimationClip animation;
        public float attRemainTime => animation.length - attDelay;
    }
}

