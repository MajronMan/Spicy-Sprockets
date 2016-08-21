using UnityEngine;
using System.Collections;
using System;

public class Cell : MonoBehaviour {
    public IntVector2 coords;
    private MeshRenderer rend;
    public MeshCollider col;
    public Building building;
   
    public Material m1, m2;
    void Start()
    {
        rend = gameObject.GetComponentInChildren<MeshRenderer>();
        col = gameObject.GetComponentInChildren<MeshCollider>();
    }

    void Update()
    {
        
    }
    public void SwitchHighlight(bool on = true)
    {
        try
        {
            if (on)
                rend.material = m1;
            else
                rend.material = m2;
        }
        catch (NullReferenceException e)
        {
            print(e.Message +" "+ coords.x+", " +coords.z);
            rend = gameObject.GetComponentInChildren<MeshRenderer>();
        }
    }
}
