using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    public class BallObjectPool : MonoBehaviour
    {
        public delegate void delegateHit(GameObject ball);
        public delegateHit onHit;


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("¦aªO"))
            {
                onHit(gameObject);
            }
        }

    }

}
