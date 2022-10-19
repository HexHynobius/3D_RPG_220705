using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hyno
{
    [DefaultExecutionOrder(200)]
    public class SpawnEnemySystem : MonoBehaviour
    {
        [SerializeField,Header("���s�ͦ��ɶ��d��")]
        private Vector2 rangeRespawn = new Vector2(2, 5);

        private ObjectPoolBee objectPoolBee;
        private GameObject enemyObject;

        private void Awake()
        {
            objectPoolBee = GameObject.Find("������e��").GetComponent<ObjectPoolBee>();

            Spawn();
        }

        private void Spawn()
        {
            enemyObject = objectPoolBee.GetPoolObject();
            enemyObject.transform.position = transform.position;

            enemyObject.GetComponent<EnemyHealth>().onDead = EnemyDead;
        }

        private void EnemyDead()
        {
            objectPoolBee.ReleasePoolObject(enemyObject);

            float randomTime = Random.Range(rangeRespawn.x, rangeRespawn.y);
            Invoke("Spawn",randomTime);
        }
    }

}

