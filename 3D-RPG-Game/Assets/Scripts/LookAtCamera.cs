using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class LookAtCamera : MonoBehaviour
    {
        Transform camTransform;
        private void Awake()
        {
            camTransform = Camera.main.transform;
        }
        private void FixedUpdate()
        {
            transform.LookAt(camTransform);
        }
    }
}
