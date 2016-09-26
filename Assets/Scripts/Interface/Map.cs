using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;
using UnityEngine.UI;
using GameControllers;

public class Map : MonoBehaviour
{
	private CityController cityController;
	private GameController gameController;
    public IntVector2 size;
    
    void Start ()
    {
        Physics.queriesHitTriggers = true;
        cityController = gameObject.transform.parent.GetComponent<CityController>();
		gameController = GameObject.Find ("Game Controller").GetComponent<GameController> ();
    }

    void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            gameController.GetGameMode().LeftMouseClicked();
        }

        if (Input.GetMouseButtonDown(1))
        {
            gameController.GetGameMode().RightMouseClicked();
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
