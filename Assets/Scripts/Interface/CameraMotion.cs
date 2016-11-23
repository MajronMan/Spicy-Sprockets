using System;
using UnityEngine;

namespace Assets.Scripts.Interface {
    /// <summary>
    /// Used to control the camera
    /// </summary>
    public class CameraMotion : MonoBehaviour {
        /// <summary>
        /// How fast the camera moves
        /// </summary>
        private float _speed;

        /// <summary>
        /// How far from the edge pointer needs to be to move the camera
        /// </summary>
        private int _boundary;

        private Vector3[] _directions;
        private Camera _myCamera;

        public void Start() {
            _speed = 0.5f;
            _boundary = 50;
            _directions = new[] {
                new Vector3(-_speed, 0, 0), //left
                new Vector3(_speed, 0, 0), //right
                new Vector3(0, -_speed, 0), //up    
                new Vector3(0, _speed, 0) //down
            };
            _myCamera = GetComponent<Camera>();
        }

        public void Update() {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && _myCamera.orthographicSize > 5) //zoom
            {
                GetComponent<Camera>().orthographicSize -= 5;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && _myCamera.orthographicSize < 35) {
                GetComponent<Camera>().orthographicSize += 5;
            }
            /*
            var deltas = new float[]
            {
                _boundary - Input.mousePosition.x,
                Input.mousePosition.x - Screen.width + _boundary,
                _boundary - Input.mousePosition.y,
                Input.mousePosition.y - Screen.height + _boundary
            };
            for (var i = 0; i < 4; i++)
                if (deltas[i] > 0)
                {
                    var newPosition = transform.position + _directions[i]*deltas[i];
                    if (Math.Abs(newPosition.x) < 30 && Math.Abs(newPosition.y) < 30)
                    {
                        transform.position = newPosition;
                    }
                }

            //was in task, not sure if we want it

            if (!Input.GetMouseButton(2)) return;

            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X"))); 
            */
            Vector3 newPosition = transform.position;

            // move camera on arrow keys down
            if (Input.GetKey("up")) {
                newPosition.y += _speed;
            }
            if (Input.GetKey("down")) {
                newPosition.y -= _speed;
            }
            if (Input.GetKey("left")) {
                newPosition.x -= _speed;
            }
            if (Input.GetKey("right")) {
                newPosition.x += _speed;
            }
            //empirical, should do it in some nicer way
            if (Math.Abs(newPosition.x - 150) < 50 && Math.Abs(newPosition.y - 150) < 50) {
                transform.position = newPosition;
            }
        }
    }
}