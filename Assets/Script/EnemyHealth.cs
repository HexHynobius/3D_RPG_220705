using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    public class EnemyHealth : HealthSystem
    {
        private EnemySystem enemySystem;


        private ObjectPoolItem objectPoolItem;

        public delegate void delegateDead();

        public delegateDead onDead;

        protected override void Awake()
        {
            base.Awake();
            enemySystem = GetComponent<EnemySystem>();

            //objectPoolItem =FindObjectOfType<ObjectPoolItem>();
            objectPoolItem = GameObject.Find("ª«¥ó¦À¸H¤ù").GetComponent<ObjectPoolItem>();
        }

        private void OnDisable()
        {
            
        }

        private void OnEnable()
        {
            hp = dataHealth.hp;
            imgHealth.fillAmount = 1;
            enemySystem.enabled = true;
        }

        protected override void Dead()
        {
            base.Dead();
            enemySystem.enabled = false;
            DropProp();
            onDead();
        }

        private void DropProp()
        {
            float value = Random.value;
            
            if(value<= dataHealth.propProbability)
            {
                Instantiate(
                    dataHealth.goProp,
                    transform.position+Vector3.up,
                    Quaternion.identity);

                GameObject tempObject = objectPoolItem.GetPoolObject();
                tempObject.transform.position = transform.position + Vector3.up * 3;

            }
            
        }

        
    }
}
