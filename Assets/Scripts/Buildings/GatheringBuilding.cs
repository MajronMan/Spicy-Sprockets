using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class GatheringBuilding : Building
{
    public float gatheringRadius;
    public Resource resource;
    private CircleCollider2D collider;
    private List<GameObject> resList;

	void Start ()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.radius = gatheringRadius;
        resList = new List<GameObject>();
	}
	
    void OnTriggerEnter(Collision col)
    {
        if(col.gameObject.GetType() == typeof(Source))
        {
            resList.Add(col.gameObject);
        }
    }
}
