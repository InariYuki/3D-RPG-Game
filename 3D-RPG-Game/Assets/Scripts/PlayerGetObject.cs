using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class PlayerGetObject : MonoBehaviour
    {
        ObjectPoolChain chainPool;
        private void Awake()
        {
            chainPool = FindObjectOfType<ObjectPoolChain>();
        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.name.Contains("hall_anchor"))
            {
                chainPool.ReleaseObject(hit.gameObject);
            }
        }
    }
}
