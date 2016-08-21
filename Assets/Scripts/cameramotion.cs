using UnityEngine;
using System.Collections;

public class cameramotion : MonoBehaviour {

    void Update()
    {
        float speed = 10f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 v = transform.right;
            transform.Translate(-v * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 v = transform.right;
            transform.Translate(v * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 v = transform.forward;
            transform.Translate(v * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 v = transform.forward;
            transform.Translate(-v*speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(speed* Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(-speed * Time.deltaTime, 0 , 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
        }

    }
}
