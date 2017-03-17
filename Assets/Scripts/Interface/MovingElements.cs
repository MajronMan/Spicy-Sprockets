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

public class MovingElements : MonoBehaviour {

    public GameObject Dude;
    public GameObject LocalMap;
    System.Random random = new System.Random();

    // Use this for initialization
    void Start () {
        LocalMap = GameObject.Find("Map");
        for (int i = 0; i <= 3; i++) //Temporary
        {
            int x = random.Next(1, 25); //Setting them in some random position
            int y = random.Next(1, 25);
            Vector3 v = new Vector3(x, y, 0);

            Dude = Instantiate(Prefabs.MovingObject, LocalMap.transform.position + v, LocalMap.transform.rotation);
            Dude.transform.SetParent(LocalMap.transform, true);
            Dude.name = "Dude" + i;
            Dude.gameObject.tag = "Dude";
            Dude.AddComponent<MovingElementsBehaviour>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		//TODO: Add the collisions between guys
        //And maybe increasing number of dudes with the growth of the population, f.e. one dude for hundred population
	}


}
