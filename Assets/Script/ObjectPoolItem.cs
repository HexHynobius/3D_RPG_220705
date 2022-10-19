using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Hyno
{
    public class ObjectPoolItem : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefabItem;
        [SerializeField]
        private int countMaxItem = 30;

        private ObjectPool<GameObject> poolItem;

        private int count;

        private void Awake()
        {
            poolItem = new ObjectPool<GameObject>(CreatePool, GetObject, ReleaseObject, DestroyObject, false, countMaxItem);
        }

        /// <summary>
        /// 建立物件池時要處理的行為
        /// </summary>
        private GameObject CreatePool()
        {
            count++;
            GameObject temp = Instantiate(prefabItem);
            temp.name = prefabItem.name + "" + count;
            return temp;
        }
        /// <summary>
        /// 物件池拿球
        /// </summary>
        private void GetObject(GameObject Item)
        {
            Item.SetActive(true);
        }
        /// <summary>
        /// 物件池還球
        /// </summary>
        public void ReleaseObject(GameObject Item)
        {
            Item.SetActive(false);
        }

        public void DestroyObject(GameObject Item)
        {
            Destroy(Item);
        }

        public GameObject GetPoolObject()
        {
            return poolItem.Get();
        }


        public void ReleasePoolObject(GameObject Item)
        {
            poolItem.Release(Item);
        }
    }

}
