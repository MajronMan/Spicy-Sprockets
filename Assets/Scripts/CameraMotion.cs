using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMotion : MonoBehaviour
    {
        public float speed = 0.25f;
        public int boundary = 32;
        private Vector3[] directions;

        public void Start()
        {
            directions = new Vector3[4]
            {
                new Vector3(-speed, 0, 0),      //left
                new Vector3(speed, 0, 0),       //right
                new Vector3(0, speed, 0),       //up    
                new Vector3(0, -speed, 0)       //down
            };
        }

        public void Update()
        {
            float[] deltas = new float[]
            {
                boundary - Input.mousePosition.x,
                Input.mousePosition.x - Screen.width + boundary,
                boundary - Input.mousePosition.y,
                Input.mousePosition.y - Screen.height + boundary
            };
            for (int i = 0; i < 4; i++)
                if (deltas[i] > 0)
                    transform.Translate(directions[i]*deltas[i]);
        }
    }
    
}
