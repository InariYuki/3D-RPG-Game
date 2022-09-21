using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class EnemyHealth : HealthSystem
    {
        ObjectPoolChain chainPool;
        EnemySystem eSys;
        Material mat;
        string matStr = "dissolveValue";
        float maxDissolve = 2 , minDissolve = -2;
        protected override void Awake()
        {
            base.Awake();
            eSys = GetComponent<EnemySystem>();
            mat = transform.Find("Casual1").GetComponent<Renderer>().material;
            chainPool = FindObjectOfType<ObjectPoolChain>();
        }
        protected override void Dead()
        {
            base.Dead();
            eSys.enabled = false;
            DropProp();
            StartCoroutine(Dissolve());
        }
        void DropProp(){
            float value = Random.value;
            if(value <= data.dropRate){
                GameObject ob = chainPool.GetObject();
                ob.transform.position = transform.position + Vector3.up * 3;
            }
        }
        IEnumerator Dissolve()
        {
            yield return new WaitForSeconds(1f);
            while (maxDissolve > minDissolve)
            {
                maxDissolve -= 0.1f;
                mat.SetFloat(matStr, maxDissolve);
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}
