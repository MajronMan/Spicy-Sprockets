using System;
using UnityEngine;
using System.Collections.Generic;

namespace GameControllers
{
    public class GameController: MonoBehaviour
	{
		//Main class used to control diplomacy, all local maps (controlled by CityController), all enemy cities (EnemyControllers) 
		public List<CityController> Cities = new List<CityController>();
		public List<EnemyController> Enemies = new List<EnemyController>();
		public Map MapPrefab;
		private GameMode gameMode;
		private int current_city = 0;

		public void Start(){
            var newGameObject = new GameObject("City Controller", typeof(CityController));
            var city_controller = newGameObject.GetComponent<CityController>();
			Cities.Add (city_controller);
			city_controller.BeginGame (MapPrefab);
		    city_controller.gameObject.transform.parent = transform;
			// later also add enemies
			gameMode = new DefaultMode();
		}

        public void Update()
        {
            gameMode.Update();
        }

		public GameMode GetGameMode()
		{
			return gameMode;
		}

		public void enterBuildingMode()
		{
			//maybe gamemode as an enum would suffice.
			gameMode=new BuildingMode(this, Cities[current_city], Cities[current_city].GetBuildingManager());
		}

		public void enterDefaultMode()
		{
			gameMode=new DefaultMode();
		}

		public CityController GetCurrentCity(){
			return Cities [current_city];
		}
	}
}

