using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hyno
{
    public class PlayAttack : AttackSystem
    {
        private ThirdPersonController tpc;

        private string parAttack = "����";

        protected override void Awake()
        {
            base.Awake();
            tpc = GetComponent<ThirdPersonController>();
        }
        private void Update()
        {
            AttackInput();
        }

        private void AttackInput()
        {
            if (!canAttack) return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                tpc.enabled=false;
                ani.SetTrigger(parAttack);
                StartAttack();
            }
        }

        protected override void StopAttack()
        {
            tpc.enabled = true;
        }

    }
}
