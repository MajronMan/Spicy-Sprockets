using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour
{

    private List<Building> Built;
    private Map MapInstance;

    public void Build(Building b, Vector2 location)
    {
        Built.Add(b);
        
    }

    public void SetMapInstance(Map MapInstance)
    {
        this.MapInstance = MapInstance;
    }

    void Start()
    {
        
    }
	// Update is called once per frame
	void Update () {
	
	}
}
