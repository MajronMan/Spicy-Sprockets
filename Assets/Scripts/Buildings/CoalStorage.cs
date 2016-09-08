using UnityEngine;
using System.Collections;

public class CoalStorage : StorageBuilding {

	// Use this for initialization
	void Start () {
        badBatch=new Coal(0, ResourceQuality.Bad);
        mediumBatch=new Coal(0,ResourceQuality.Medium);
        goodBatch=new Coal(0, ResourceQuality.Good);
	}

   
	
	// Update is called once per frame
	void Update () {
	
	}
}
