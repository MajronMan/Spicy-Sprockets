using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A template for user and enemy
/// </summary>
public abstract class Player : MonoBehaviour {

    private Dictionary<string,Trait> traits;

    public virtual void Start() {
        traits = new Dictionary<string, Trait>();
    }
}
