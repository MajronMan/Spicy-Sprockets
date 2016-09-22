using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BuildingManager : MonoBehaviour
{

    private List<Building> Built;
    private Map mapInstance;
    //for now it's more convenient to hold this variable in this script, but I think we should aim for this script not to need to keep it
    public Building TMPBuildingPrefab;
    //
    public Building tentPrefab;
    private bool active = false;
    private string val;
    public Building preview;
    public BuildingStub OPTRTA;
    private StorageBuilding korwo;


    public void Build(Building buildingPrefab, Vector3 location)
    {
        Building newBuilding = Instantiate(buildingPrefab);
        newBuilding.transform.position = Camera.main.ScreenToWorldPoint(location);
        newBuilding.transform.localScale = new Vector3(20, 20, 20);
        newBuilding.transform.SetParent(mapInstance.transform, true);
        this.active = false;
        //////////////////
        BuildingStub someOther = Instantiate(OPTRTA);
       
        //someOther.init(StorageBuilding);
        someOther.init(BuildingType.Production);
        Destroy(someOther);
        

    }
    
    
    public void SetMapInstance(Map MapInstance)
    {
        this.mapInstance = MapInstance;
    }

    void Start()
    {
        Debug.Log("karwia");
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
        return TMPBuildingPrefab;
    }

    public void createPreview(Building buildingPrefab)
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
