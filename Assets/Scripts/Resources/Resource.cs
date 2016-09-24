using UnityEngine;
using System.Collections;

[System.Serializable]
public class Resource : MonoBehaviour
{
    private int massPerUnit;
    private int volumePerUnit;
    private int defaultCostPerUnit;
    private int quantity;
    private ResourceQuality quality;
    private ResourceType.Type resType;
    
    
    public Resource(ResourceType.Type type, int quantity, ResourceQuality quality)
    {
        LoadProperties(type);
        this.quantity = quantity;
        this.quality = quality;
        this.resType = type;
    }
    
    public ResourceQuality getQuality()
    {
        return quality;
    }

    public int getQuantity()
    {
        return quantity;
    }
    
    public static Resource operator +(Resource basicRes, int addedQuantity)
    {
        basicRes.quantity += addedQuantity;
        return basicRes;
    }

    public static Resource operator -(Resource basicRes, int subtractedQuantity)
    {
        basicRes.quantity -= subtractedQuantity;
        return basicRes;
    }

    public static Resource operator ++(Resource basicRes)
    {
        basicRes.quantity++;
        return basicRes;
    }

    public static Resource operator --(Resource basicRes)
    {
        basicRes.quantity--;
        return basicRes;
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void LoadProperties(ResourceType.Type type)
    {
        switch (type)
        {
            case ResourceType.Type.Coal:
                massPerUnit = ResourceType.Coal.massPerUnit;
                volumePerUnit = ResourceType.Coal.volumePerUnit;
                defaultCostPerUnit = ResourceType.Coal.defaultCostPerUnit;
                name = ResourceType.Coal.name;
                break;
            default:
                massPerUnit = 2137;
                volumePerUnit = 410;
                defaultCostPerUnit = 15;
                name = "yomama";
                break;

        }
    }

    public Resource Divide(int newQuantity)
    {
        if(newQuantity > quantity)
        {
            Debug.Log("Cant subtract");
            return this;
        }

        Resource newRes = new Resource(resType, newQuantity, quality);
        quantity -= newQuantity;
        return newRes;
    }

    public Resource Fuse(Resource newRes)
    {
        quantity = newRes.quantity;
        //trzeba pozniej zmienic zeby quality jakos wplywalo
        Destroy(newRes);
        return this;
    }
}
