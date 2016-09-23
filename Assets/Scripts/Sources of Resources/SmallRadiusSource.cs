using UnityEngine;
using System.Collections;

public class SmallRadiusSource : Source
{
    protected override void Start()
    {
        radius = 20;
        resource = new Resource(ResourceType.Type.Coal, 10, ResourceQuality.Good);
        circle = GetComponent<CircleCollider2D>();
        circle.radius = radius;
    }

}
