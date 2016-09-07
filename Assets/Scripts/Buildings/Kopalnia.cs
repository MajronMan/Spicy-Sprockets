using UnityEngine;
using System.Collections;

public class Kopalnia : GatheringBuilding {

	// Use this for initialization
	void Start ()
    {
        gatheringRadius = gameObject.GetComponent<CircleCollider2D>().radius;
        if (gatheringRadius == null) gatheringRadius = 0;
        resource=new Wungiel();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
