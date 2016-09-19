using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public abstract class Source : MonoBehaviour
{
    protected float radius;
    protected Resource resource;
    protected CircleCollider2D circle;

    public float resourceQuantity(float distance)
    {
        float res;
        if (distance > radius) res = 0;
        else res = Mathf.Cos((Mathf.PI / (2 * radius)) * distance) * resource.getQuantity();
        return res;
    }

    public float gatheringSpeed(float distance)
    {
        if (distance >= radius)
            return 0;
        else
            return Mathf.Cos((Mathf.PI / (2 * radius)) * distance);
    }

	protected virtual void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}
}
