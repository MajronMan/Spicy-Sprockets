using UnityEngine;
using System.Collections;

public class UnbuildableTerrain : MonoBehaviour
{

    private BoxCollider2D collider;
	// Use this for initialization
	void Start ()
	{
	    gameObject.AddComponent < BoxCollider2D>();
	    collider = gameObject.GetComponent<BoxCollider2D>();
	    collider.size=new Vector2(5,5);
	    collider.isTrigger = false;


	}


    
	// Update is called once per frame
	void Update () {
        
	
	}
}
