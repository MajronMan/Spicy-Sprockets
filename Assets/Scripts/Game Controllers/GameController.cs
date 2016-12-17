using System.Collections.Generic;
using Assets.Scripts.Game_Controllers.Game_Modes;
using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers {
    /// <summary>
    /// Main class used to control diplomacy, all local maps (controlled by CityController), all enemy cities (EnemyControllers) 
    /// </summary>
    public class GameController : MonoBehaviour {
        public List<CityController> Cities = new List<CityController>();
        public List<EnemyController> Enemies = new List<EnemyController>();
        public ScienceController Science;
        public Map MapPrefab;
        private IGameMode _gameMode;
        private int _currentCity = 0;

        //cannot wait until first frame with start, so calling this explicitly
        public void BeginGame() {
            var newGameObject = new GameObject("City Controller", typeof(CityController));
            var cityController = newGameObject.GetComponent<CityController>();
            Cities.Add(cityController);
            cityController.CreateCity(MapPrefab);
            cityController.transform.SetParent(transform, true);
            // later also add enemies
            _gameMode = new DefaultMode();
        }

        public void Update() {
            _gameMode.Update();

            //Now you can pause the game by pressing 'p'
            if (Input.GetKeyDown("p")) {
                Debug.Break();
            }
        }

        public IGameMode GetGameMode() {
            return _gameMode;
        }


        //isn't that work for building manager?
        public void EnterBuildingMode(System.Type buildingType) {
            if (!_checkSufficientResources(buildingType)) {
                Debug.Log("Insufficient resources!");
                return;
            }
            _gameMode = new BuildingMode(buildingType);
        }

        public void EnterDefaultMode() {
            _gameMode = new DefaultMode();
        }

        public CityController GetCurrentCity() {
            return Cities[_currentCity];
        }

        private bool _checkSufficientResources(System.Type buildingType) {
            return Controllers.CurrentInfo.SufficientResources(Controllers.ConstantData.BuildingCosts[buildingType]);
        }
    }
}