using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BuildingManager : MonoBehaviour
{

    private List<Building> Built;
    private Map mapInstance;
    public Building buildingPrefab;
    public Building tentPrefab;
    private bool active = false;
    private string val;
    public Building preview;


    public void Build(Vector3 location)
    {
        Building newBuilding = Instantiate(buildingPrefab);
        newBuilding.transform.position = Camera.main.ScreenToWorldPoint(location);
        newBuilding.transform.localScale = new Vector3(20, 20, 20);
        newBuilding.transform.SetParent(mapInstance.transform, true);
        this.active = false;
    }
    
    
    public void SetMapInstance(Map MapInstance)
    {
        this.mapInstance = MapInstance;
    }

    void Start()
    {
        
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
    public void setValue(string value)
    {
        val = value;
    }
    public string getValue()
    {
        return val;
    }

    public Building getBuildingPrefab()
    {
        return buildingPrefab;
    }

    public void createPreview()
    {
        preview = Instantiate(buildingPrefab);
        preview.transform.localScale = new Vector3(20, 20, 20);
        preview.name = "Building Preview";
        preview.transform.parent = transform;
    }

    public void DestroyPreview()
    {
        Destroy(preview.gameObject);
    }

    
}
