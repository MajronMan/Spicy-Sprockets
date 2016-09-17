using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMotion : MonoBehaviour
    {
        private float speed;
        private int boundary;
        private Vector3[] directions;

        public void Start()
        {
            speed = 0.025f;
            boundary = 32;
            directions = new Vector3[4]
            {
                new Vector3(-speed, 0, 0),      //left
                new Vector3(speed, 0, 0),       //right
                new Vector3(0, -speed, 0),       //up    
                new Vector3(0, speed, 0)       //down
            };
        }

        public void Update()
        {
            if (Math.Abs(transform.position.x) > 2000 || Math.Abs(transform.position.y) > 2000) return;
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

            //was in task, not sure if we want it

            if (!Input.GetMouseButton(2)) return;

            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X"))); 
        }
    }
    
}
