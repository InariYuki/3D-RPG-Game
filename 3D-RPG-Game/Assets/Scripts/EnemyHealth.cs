using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class EnemyHealth : HealthSystem
    {
        EnemySystem eSys;
        protected override void Awake()
        {
            base.Awake();
            eSys = GetComponent<EnemySystem>();
        }
        protected override void Dead()
        {
            base.Dead();
            eSys.enabled = false;
            DropProp();
        }
        void DropProp(){
            float value = Random.value;
            if(value <= data.dropRate){
                Instantiate(data.prop , transform.position + Vector3.up * 3 , Quaternion.identity);
            }
        }
    }
}
