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

    
    public Building init(System.Type type)
    {
        return (Building)gameObject.AddComponent(type);
    }
    
}
