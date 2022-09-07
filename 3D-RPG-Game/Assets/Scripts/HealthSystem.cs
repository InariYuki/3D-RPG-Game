using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KitsuneYuki
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] DataHealth data;
        float HP;
        Animator anim;
        [SerializeField] Image healthBar;
        AttackSystem ats;
        protected virtual void Awake()
        {
            anim = GetComponent<Animator>();
            HP = data.HP;
            ats = GetComponent<AttackSystem>();
        }
        public void Hurt(float damage)
        {
            HP -= damage;
            healthBar.fillAmount = HP / data.maxHP;
            anim.SetTrigger("triggerHit");
            if (HP <= 0) Dead();
        }
        protected virtual void Dead()
        {
            HP = 0;
            anim.SetBool("boolDead", true);
            ats.enabled = false;
        }
    }
}
