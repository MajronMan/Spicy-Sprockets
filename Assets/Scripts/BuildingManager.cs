using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BuildingManager : MonoBehaviour
{

    private List<Building> Built;
    private Map mapInstance;
    public Building buildingPrefab;
    public bool active;

    public void Build(Vector2 location)
    {
        Building newBuilding = Instantiate(buildingPrefab);
        newBuilding.transform.position = location;
        newBuilding.transform.parent = mapInstance.transform;


    }

    public void SetMapInstance(Map MapInstance)
    {
        this.mapInstance = MapInstance;
    }
   

    public void elo()
    {
        Debug.Log("Elo");
    }
    void Start()
    {
        active = true;

    }
	// Update is called once per frame
	void Update () {
	
	}

    public void setActive(bool active)
    {
        this.active = active;
    }

    public bool getActive()
    {
        return active;
    }
}
