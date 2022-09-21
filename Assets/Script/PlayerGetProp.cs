using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hyno
{
    public class PlayerGetProp : MonoBehaviour
    {
        private ObjectPoolItem objectPoolItem;
        private string propItem = "¹D¨ã";

        private void Awake()
        {
            objectPoolItem =FindObjectOfType<ObjectPoolItem>();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.name.Contains(propItem))
            {
                objectPoolItem.ReleaseObject(hit.gameObject);
            }
        }

    }

}
