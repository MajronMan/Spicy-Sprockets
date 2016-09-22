using UnityEngine;
using System.Collections;

[System.Serializable]
public class Resource : MonoBehaviour
{
    protected int massPerUnit;
    protected int volumePerUnit;
    protected int defaultCostPerUnit;
    protected int quantity;
    protected ResourceQuality quality;
    
    
    public Resource(ResourceType.Type type, int quantity, ResourceQuality quality)
    {
        LoadProperties(type);
        this.quantity = quantity;
        this.quality = quality;
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
}
