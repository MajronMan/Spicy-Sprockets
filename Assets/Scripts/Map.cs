using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    private StrategyManager strategyManager;
    public Building buildingPrefab;

    public void Start()
    {
        Physics.queriesHitTriggers = true;
        strategyManager = gameObject.transform.parent.GetComponent<StrategyManager>();
    }

    public void OnMouseDown()
    {
        strategyManager.MapClicked();
    }

    public int objectIndex()
    {
        return gameObject.transform.GetSiblingIndex();
    }
}
