using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class SpawnBall : MonoBehaviour
    {
        [SerializeField] GameObject ball;
        private void Start()
        {
            InvokeRepeating("Spawn" , 0 , 0.1f);
        }
        void Spawn()
        {
            Instantiate(ball, new Vector3(Random.Range(-15f , 15f) , Random.Range(5f , 10f) , Random.Range(-15f , 15f)), Quaternion.identity);
        }
    }
}
