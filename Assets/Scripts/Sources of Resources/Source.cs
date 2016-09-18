using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public abstract class Source : MonoBehaviour
{
    protected float radius;
    protected Resource resource;
    protected CircleCollider2D circle;

    public float recourceQuantity(float distance)
    {
        float res;
        if (distance > radius) res = 0;
        else res = radius*radius - distance*distance;
        return res;
    }

	protected virtual void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}
}
