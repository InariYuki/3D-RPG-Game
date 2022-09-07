using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class PlayerHealth : HealthSystem
    {
        ThirdPersonController tps;
        protected override void Awake()
        {
            base.Awake();
            tps = GetComponent<ThirdPersonController>();
        }
        protected override void Dead()
        {
            base.Dead();
            tps.enabled = false;
        }
    }
}
