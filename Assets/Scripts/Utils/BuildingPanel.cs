using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Buildings;

[System.Serializable]
public class BuildingPanel : MonoBehaviour
{
    public Text text;
    public Slider slider;
    public GatheringBuilding motherBuilding;

	void Start ()
    {
        slider.minValue = 0;
        slider.maxValue = motherBuilding.MaxStaff;

        int staff = motherBuilding.CurrentStaff;
        staff.ToString();
        text.text = "Employees: " + staff;
        transform.SetParent(motherBuilding.transform);
	}

    public void ManageWorkers()
    {
        int newStaff = (int)slider.value;
        motherBuilding.ManageStaff(newStaff);
        newStaff.ToString();
        text.text = "Employees: " + newStaff;
    }
	
}
