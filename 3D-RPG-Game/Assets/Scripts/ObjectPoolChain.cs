using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace KitsuneYuki
{
    public class ObjectPoolChain : MonoBehaviour
    {
        [SerializeField] GameObject chain;
        [SerializeField] int maxAmount = 20;
        int count;
        ObjectPool<GameObject> chainPool;
        private void Awake()
        {
            chainPool = new ObjectPool<GameObject>(CreateChain , GetChain , ReleaseChain , DestroyChain , false , maxAmount);
        }
        GameObject CreateChain()
        {
            count++;
            GameObject obj = Instantiate(chain);
            obj.name = chain.name + " " + count;
            return obj;
        }
        void GetChain(GameObject obj)
        {
            obj.SetActive(true);
        }
        void ReleaseChain(GameObject obj)
        {
            obj.SetActive(false);
        }
        void DestroyChain(GameObject obj)
        {
            Destroy(obj);
        }
        public GameObject GetObject()
        {
            return chainPool.Get();
        }
        public void ReleaseObject(GameObject obj)
        {
            chainPool.Release(obj);
        }
    }
}
