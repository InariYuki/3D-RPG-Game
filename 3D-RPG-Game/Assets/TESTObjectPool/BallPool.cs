using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace KitsuneYuki
{
    public class BallPool : MonoBehaviour
    {
        [SerializeField] GameObject ball;
        ObjectPool<GameObject> ballPool;
        private void Awake()
        {
            ballPool = new ObjectPool<GameObject>(CreateBall , GetBall , ReleaseBall , DestroyBall , false , 1000);
            InvokeRepeating("Spawn" , 0 , 0.1f);
        }
        GameObject CreateBall()
        {
            return Instantiate(ball);
        }
        void GetBall(GameObject ball)
        {
            ball.SetActive(true);
        }
        void ReleaseBall(GameObject ball)
        {
            ball.SetActive(false);
        }
        void DestroyBall(GameObject ball)
        {
            Destroy(ball);
        }
        void Spawn()
        {
            GameObject b = ballPool.Get();
            b.transform.position = new Vector3(Random.Range(-15f, 15f), Random.Range(5f, 10f), Random.Range(-15f, 15f));
            b.GetComponent<RecycleBall>().OnHit = RecycleBall;
        }
        void RecycleBall(GameObject obj)
        {
            ballPool.Release(obj);
        }
    }
}
