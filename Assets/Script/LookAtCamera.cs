using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    public class LookAtCamera : MonoBehaviour
    {
        private Transform traCamera;

        private void Awake()
        {
            traCamera = Camera.main.transform;
        }

        private void Update()
        {
            LookAt();
        }

        private void LookAt()
        {
            transform.LookAt(traCamera);
        }
    }

}
