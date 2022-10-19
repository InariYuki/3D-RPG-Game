using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    [DefaultExecutionOrder(200)]
    public class EnemySpawner : MonoBehaviour
    {
        ObjectPoolCony enemyPool;
        GameObject enemy;
        private void Awake()
        {
            enemyPool = GameObject.Find("PoolCony").GetComponent<ObjectPoolCony>();
            Spawn();
        }
        void Spawn()
        {
            enemy = enemyPool.GetObject();
            enemy.transform.position = transform.position;
            enemy.GetComponent<EnemyHealth>().onDead = EnemyDead;
        }
        void EnemyDead()
        {
            enemyPool.ReleaseObject(enemy);
            float randomTime = Random.Range(2f , 5f);
            Invoke("Spawn" , randomTime);
        }
    }
}
