using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class PlayerAttack : AttackSystem
    {
        
        protected override void Awake()
        {
            base.Awake();
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
