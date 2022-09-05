using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class PlayerAttack : AttackSystem
    {
        Animator anim;
        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        private void Update()
        {
            if (!canAttack) return;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("triggerAttack");
                Attack();
            }
        }
    }
}
