using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public abstract class Source : MonoBehaviour
{
    protected float radius;
    protected Resource resource;

    public float recourceQuantity(float distance)
    {
        float res;
        if (distance > radius) res = 0;
        else res = radius*radius - distance*distance;
        return res;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
