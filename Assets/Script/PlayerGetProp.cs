using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


namespace Hyno
{
    public class PlayerGetProp : MonoBehaviour
    {
        private ObjectPoolItem objectPoolItem;
        private string propItem = "道具";
        private int countItem = 0;
        private int countItemMax = 1;
        private TextMeshProUGUI textCount;

        private void Awake()
        {
            //objectPoolItem = FindObjectOfType<ObjectPoolItem>();
            objectPoolItem = GameObject.Find("物件池碎片").GetComponent<ObjectPoolItem>();

            textCount = GameObject.Find("道具數量介面").GetComponent<TextMeshProUGUI>();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.name.Contains(propItem))
            {
                objectPoolItem.ReleaseObject(hit.gameObject);
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            textCount.text = "道具 " + (++countItem) + " / " + countItemMax;
        }

    }

}
