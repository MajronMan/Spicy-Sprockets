using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BuildingManager : MonoBehaviour
{

    private List<Building> Built;
    private Map MapInstance;
    public Building buildingPrefab;

    private  void Build(Vector2 location)
    {
        Building newBuilding = Instantiate(buildingPrefab);
        newBuilding.transform.parent = transform;
        newBuilding.transform.position = location;
        

    }

    public void SetMapInstance(Map MapInstance)
    {
        this.MapInstance = MapInstance;
    }
    void OnMouseDown()
    {
        Debug.Log("Building");
        Build(Input.mousePosition);
    }
    void Start()
    {
        
    }
	// Update is called once per frame
	void Update () {
	
	}
}
