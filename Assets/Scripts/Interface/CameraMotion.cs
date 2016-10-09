﻿using System;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class CameraMotion : MonoBehaviour
    {
        private float _speed;
        private int _boundary;
        private Vector3[] _directions;

        public void Start()
        {
            _speed = 0.05f;
            _boundary = 50;
            _directions = new Vector3[4]
            {
                new Vector3(-_speed, 0, 0),      //left
                new Vector3(_speed, 0, 0),       //right
                new Vector3(0, -_speed, 0),       //up    
                new Vector3(0, _speed, 0)       //down
            };
        }

        public void Update()
        {/*
            if (Math.Abs(transform.position.x) > 2000 || Math.Abs(transform.position.y) > 2000) return;
            var deltas = new float[]
            {
                _boundary - Input.mousePosition.x,
                Input.mousePosition.x - Screen.width + _boundary,
                _boundary - Input.mousePosition.y,
                Input.mousePosition.y - Screen.height + _boundary
            };
            for (var i = 0; i < 4; i++)
                if (deltas[i] > 0)
                    transform.Translate(_directions[i]*deltas[i]);

            //was in task, not sure if we want it

            if (!Input.GetMouseButton(2)) return;

            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X"))); */
        }
    }
    
}