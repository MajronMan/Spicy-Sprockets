using UnityEngine;
using System.Collections;


public class BuildingStub : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
      
	
	}

    
    public void init(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Production:
                gameObject.AddComponent<ProductionBuilding>();
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
    
}
