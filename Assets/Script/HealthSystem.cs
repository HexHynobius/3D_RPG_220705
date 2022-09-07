using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hyno
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField, Header("��q���")]
        protected DataHealth dataHealth;
        [SerializeField, Header("��q")]
        private Image imgHealth;

        private float hp;
        private Animator ani;
        private string parHurt = "Ĳ�o����";
        private string parDead = "Ĳ�o���`";
        private AttackSystem attackSystem;



        protected virtual void Awake()
        {
            ani = GetComponent<Animator>();
            attackSystem = GetComponent<AttackSystem>();
            hp = dataHealth.hp;
        }

        public void Hurt(float damage)
        {
            hp -= damage;
            ani.SetTrigger(parHurt);

            if (hp <= 0) Dead();


            imgHealth.fillAmount = hp / dataHealth.hpMax;

        }

        protected virtual void Dead()
        {
            hp = 0;
            ani.SetBool(parDead, true);
            attackSystem.enabled = false;
        }


    }
}
