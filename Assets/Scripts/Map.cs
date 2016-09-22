using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    private StrategyManager strategyManager;
    public IntVector2 size;
    
    void Start ()
    {
        Physics.queriesHitTriggers = true;
        strategyManager = gameObject.transform.parent.GetComponent<StrategyManager>();
    }

    void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            strategyManager.GetGameMode().LeftMouseClicked();
        }

        if (Input.GetMouseButtonDown(1))
        {
            strategyManager.GetGameMode().RightMouseClicked();
        }
        //strategyManager.mapClicked();
            
        
    }
    
	void OnMouseOver(){
		//strategyManager.MouseOver();
	}

    public int objectIndex()
    {
        return gameObject.transform.GetSiblingIndex();
    }
    
}
