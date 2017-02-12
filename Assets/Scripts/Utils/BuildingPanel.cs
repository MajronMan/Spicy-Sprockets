//using Assets.Scripts.Buildings;
//using UnityEngine;
//using UnityEngine.UI;
//
//namespace Assets.Scripts.Utils
//{
//    [System.Serializable]
//    public class BuildingPanel : MonoBehaviour {
//        public Text Text;
//        public Slider Slider;
//        public GatheringBuilding MotherBuilding;
//
//        void Start() {
//            Slider.minValue = 0;
//            Slider.maxValue = MotherBuilding.MaxStaff;
//
//            int staff = MotherBuilding.CurrentStaff;
//            Text.text = "Employees: " + staff;
//            transform.SetParent(MotherBuilding.transform);
//        }
//
//        public void ManageWorkers() {
//            int newStaff = (int) Slider.value;
//            MotherBuilding.ManageStaff(newStaff);
//            Text.text = "Employees: " + newStaff;
//        }
//    }
//}