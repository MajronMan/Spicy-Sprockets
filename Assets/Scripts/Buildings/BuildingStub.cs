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
        Building res = null;
        res = (Building)gameObject.AddComponent(type);
        /*
        switch (type)
        {
            case BuildingType.Production:
                res= gameObject.AddComponent<ProductionBuilding>();
                res = (Building)gameObject.AddComponent(type);
                    
                break;
            default:
                Destroy(gameObject);
                break;
        }
        */
        return res;
    }
    
}
