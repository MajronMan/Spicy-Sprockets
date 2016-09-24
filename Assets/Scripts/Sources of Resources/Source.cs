using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;
using Assets.Scripts.Resources;

public abstract class Source : MonoBehaviour
{
    protected float radius;
    protected Resource resource;
    protected CircleCollider2D circle;

    public float resourceQuantity(float distance)
    {
        float res;
        if (distance > radius) res = 0;
        //else res = Mathf.Cos((radius / (8 * Mathf.PI)) * distance) * resource.getQuantity();
        return 0.0f;
    }

    public ResourceGatheringRate gatheringSpeed(float distance)
    {
        if (distance >= radius)
            return ResourceGatheringRate.Static;
        if((distance / radius) >= 0.8)
            return ResourceGatheringRate.VerySlow;
        if ((distance / radius) >= 0.6)
            return ResourceGatheringRate.Slow;
        if ((distance / radius) >= 0.4)
            return ResourceGatheringRate.Medium;
        if ((distance / radius) >= 0.2)
            return ResourceGatheringRate.Fast;
        else
            return ResourceGatheringRate.VeryFast;
    }

	protected virtual void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}
}
