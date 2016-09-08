using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Resource : MonoBehaviour
{
    protected int massPerUnit;
    protected int volumePerUnit;
    protected int defaultCostPerUnit;
    protected int quantity;
    protected ResourceQuality quality;
    
    
    public Resource(int quantity, ResourceQuality quality)
    {
        this.quantity = quantity;
        this.quality = quality;
    }

    

    

    public int getQuantity()
    {
        return quantity;
    }

    public void setQuantity(int quantity)
    {
        this.quantity = quantity;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public ResourceQuality getQuality()
    {
        return quality;
    }
    
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
