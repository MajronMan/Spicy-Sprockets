using UnityEngine;
using System.Collections;
using UnityEditor;


public class BuildingStub : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
      
	
	}


    public Building init(System.Type type, Info info)
    {
        Building building = (Building)gameObject.AddComponent(type);
        building.info = info;
        return building;
    }
    
}
