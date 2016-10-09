using System.Collections.Generic;
using Assets.Scripts.Buildings;
using Assets.Scripts.Game_Controllers.Game_Modes;
using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers
{
    public class GameController: MonoBehaviour
	{
		//Main class used to control diplomacy, all local maps (controlled by CityController), all enemy cities (EnemyControllers) 
		public List<CityController> Cities = new List<CityController>();
		public List<EnemyController> Enemies = new List<EnemyController>();
		public Map MapPrefab;
		private IGameMode _gameMode;
		private int _currentCity = 0;

        //cannot wait until first frame with start, so calling this explicitly
		public void BeginGame(){
            var newGameObject = new GameObject("City Controller", typeof(CityController));
            var cityController = newGameObject.GetComponent<CityController>();
			Cities.Add (cityController);
			cityController.BeginGame (MapPrefab);
		    cityController.gameObject.transform.parent = transform;
			// later also add enemies
			_gameMode = new DefaultMode();
		}

        public void Update()
        {
            _gameMode.Update();
            
            //Now you can pause the game by pressing 'p'
            if (Input.GetKeyDown("p"))
            {
                Debug.Break();
            }
        }

		public IGameMode GetGameMode()
		{
			return _gameMode;
		}

		public void EnterBuildingMode(System.Type buildingType)
		{
			_gameMode=new BuildingMode(buildingType, this);
		}

		public void EnterDefaultMode()
		{
			_gameMode=new DefaultMode();
		}

		public CityController GetCurrentCity(){
			return Cities [_currentCity];
		}
	}
}

