using Assets.Scripts.Buildings;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers {
    public class GameControllerReferencer : MonoBehaviour {
        void Awake() {
            GameController unused = Controllers.GameController;
        }

        //it's just a temporary solution, becasue built-in button script cannot call static methods
        //apparently neither can it call something that returns non-void or takes something that's not string, int or bool
        public void ReferenceBuild(string type) {
            switch (type) {
                case "tent":
                    Controllers.GameController.EnterBuildingMode(typeof(ResidentialBuilding));
                    break;
                case "storage":
                    Controllers.GameController.EnterBuildingMode(typeof(StorageBuilding));
                    break;
                case "production":
                    Controllers.GameController.EnterBuildingMode(typeof(ProductionBuilding));
                    break;
                default:
                    Controllers.GameController.EnterBuildingMode(typeof(ProductionBuilding));
                    break;
            }
        }
    }
}