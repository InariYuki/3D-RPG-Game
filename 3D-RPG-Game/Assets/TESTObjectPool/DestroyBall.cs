using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki{
    public class DestroyBall : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject , 10f);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "Floor")
            {
                Destroy(gameObject);
            }
        }
    }
}
