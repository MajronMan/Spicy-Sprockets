using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;
using Assets.Scripts.Interface;
using Assets.Static;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovingElementsBehaviour : MonoBehaviour
{
    System.Random random = new System.Random();
    // Use this for initialization
    void Start()
    {
        StartCoroutine(MoveDude(gameObject));
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.gameObject.tag == "Dude")
        {
            StopAllCoroutines();
            //StopCoroutine(MoveDude(gameObject)); //I don't know why this won't work
            StartCoroutine(MoveDude(gameObject));
            //I don't know what i want on collision. When I tried to start another coroutine magic happens
            //Somehow they are fusing
            //And I don't know how to make them bounce off each other
        }
    }

    public IEnumerator MoveDude(GameObject MovedElement)
    {
        while (true)
        {
            int r = random.Next(1, 8);
            int x = random.Next(1, 25); //TODO: Make them move only on the map
            int y = random.Next(1, 25); //Actually they move only on map - they move on maximum distance of 15 in X and Y from 0,0,0 global position
            Vector3 vec = new Vector3(x, y, 0);
            Vector3 vd = new Vector3(System.Math.Abs(MovedElement.transform.position.x - x), System.Math.Abs(MovedElement.transform.position.y - y));
            float dist = vd.magnitude;
            float vel = 2.5f; //Some constant velocity
            float time = dist / vel;
            iTween.MoveTo(MovedElement, iTween.Hash("position", vec, "time", time, "easetype", "linear"));
            //Debug.Log(x + " " + y + " " + dist + " " + time);
            if(r == 7)
            {
                time = time * 10;
            }
            yield return new WaitForSeconds(time);
        }
    }
}
