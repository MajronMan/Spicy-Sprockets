using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Resource : MonoBehaviour
{
    public int massPerUnit;
    public int volumePerUnit;
    protected int defaultCost;
    public int quantity;
    public int quality;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
