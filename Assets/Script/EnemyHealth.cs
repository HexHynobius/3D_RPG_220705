using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    public class EnemyHealth : HealthSystem
    {
        private EnemySystem enemySystem;


        private ObjectPoolItem objectPoolItem;

        protected override void Awake()
        {
            base.Awake();
            enemySystem = GetComponent<EnemySystem>();

            objectPoolItem =FindObjectOfType<ObjectPoolItem>();
        }
        protected override void Dead()
        {
            base.Dead();
            enemySystem.enabled = false;
            DropProp();
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
