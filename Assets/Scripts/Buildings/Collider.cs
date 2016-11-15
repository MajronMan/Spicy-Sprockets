using UnityEngine;
using System.Collections;

public class Collider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public static BoxCollider2D addCollider (GameObject to, Vector2 size, Vector3 where, Transform parent)
    {
        to.layer = 8;

        to.AddComponent<BoxCollider2D>();
        var newCollider = to.GetComponent<BoxCollider2D>();

        newCollider.transform.position = where;
        newCollider.transform.SetParent(parent, true);
        newCollider.enabled = true;
        newCollider.isTrigger = false;
        //need to change it so that size depends on building type 
        //(couldn't make it work with sprite sizes, will look into it as well)
        newCollider.size = size;
        return newCollider;
    }

    public static Rigidbody2D addFakeRigidBody (GameObject to)
    {
        to.AddComponent<Rigidbody2D>();
        var newRigidBody = to.GetComponent<Rigidbody2D>();
        //newRigidBody.angularDrag = 0;
        //newRigidBody.angularVelocity = 0;
        //newRigidBody.constraints = 0;
        //newRigidBody.drag = 0;
        //newRigidBody.inertia = 0;
        newRigidBody.gravityScale = 0;
        newRigidBody.freezeRotation = true;
        newRigidBody.mass = 0;
        newRigidBody.rotation = 0;
        //newRigidBody.simulated = false;
        return newRigidBody;
    }

}
