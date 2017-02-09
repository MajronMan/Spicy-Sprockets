using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class Trait : MonoBehaviour{
    private float value;
    //for now I skip min and max, it should be 0 and 1 to all imho
    /// <summary>
    /// value at which the trait is activated
    /// </summary>
    private float actiVal;
    /// <summary>
    /// value at which the trait is disabled
    /// </summary>
    private float deactiVal;
    private bool isActive;
    public string TraitName;

    public Trait(string name) {
        TraitName = name;
        isActive = false;
        value = 0;
        LoadFromFile();
    }

    public void UpgradeTrait(float val){
        value += val;
        if (value > 1)
            value = 1;
        if (value >= actiVal && isActive == false)
            isActive = true;
    }

    public void DowngradeTrait(float val){
        value -= val;
        if (value < 0)
            value = 0;
        if (value <= deactiVal && isActive)
            isActive = false;
    }

    public bool CheckIfActive() {
        return isActive;
    }

    private void LoadFromFile() {
        //using a file to set actiVal and deactiVal
        StreamReader reader = new StreamReader("Assets/Static/Traits.txt", Encoding.Default);
        //TODO change txt to json
        string line;
        using (reader)
        {
            do
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    string[] entries = line.Split(',');
                    try
                    {
                        if (entries[0] == name)
                        {
                            deactiVal = float.Parse(entries[1]);
                            actiVal = float.Parse(entries[2]);
                            break;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Debug.Log("Error in Traits.txt format");
                    }
                }
            }
            while (line != null);
            reader.Close();
        }
    }
}
