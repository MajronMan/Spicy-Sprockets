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
    
    

	// Use this for initialization
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
