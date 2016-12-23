using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class NotRotating : MonoBehaviour
    {
        private Quaternion _rotation;
        public void Start()
        {
            _rotation = transform.rotation;
        }

        public void LateUpdate()
        {
            transform.rotation = _rotation;
        }
    }
}
