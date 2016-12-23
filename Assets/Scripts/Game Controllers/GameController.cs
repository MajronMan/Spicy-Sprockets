using System.Collections.Generic;
using Assets.Scripts.Game_Controllers.Game_Modes;
using Assets.Scripts.Interface;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game_Controllers {
    /// <summary>
    /// Main class used to control diplomacy, all local maps (controlled by CityController), all enemy cities (EnemyControllers) 
    /// </summary>
    public class GameController: MonoBehaviour
	{
		public List<CityController> Cities = new List<CityController>();
		public List<EnemyController> Enemies = new List<EnemyController>();
        /// <summary>
        /// The base game object which is parent to everything
        /// </summary>
	    public GameObject Root;
        /// <summary>
        /// Where Local UI is drawn
        /// </summary>
	    public GameObject LocalMapCanvas;
        /// <summary>
        /// Where Global UI is drawn
        /// </summary>
        public GameObject GlobalMapCanvas;

        /// <summary>
        /// Bool used to specify whether it's the first open of global map if so - instantiates global map UI
        /// </summary>
        private bool _firstOpen = true;

		private IGameMode _gameMode;
		private int _currentCity = 0;
	    public Camera MainCamera;
        
        //cannot wait until first frame with start, so calling this explicitly
        public void BeginGame() {
            CreateUI();
            var newGameObject = new GameObject("City Controller", typeof(CityController));
            var cityController = newGameObject.GetComponent<CityController>();
            Cities.Add(cityController);
            cityController.CreateCity();
            cityController.transform.SetParent(transform, true);
            // later also add enemies
            _gameMode = new DefaultMode();
        }

        /// <summary>
        /// Method creating main interface automatically - local map interface
        /// </summary>
	    private void CreateUI()
	    {
	        Root = Instantiate(Prefabs.Root);
	        MainCamera = Root.GetComponentInChildren<Camera>();
	        LocalMapCanvas = Instantiate(Prefabs.Canvas);
            LocalMapCanvas.transform.SetParent(Root.transform, false);
	        LocalMapCanvas.AddComponent<AutomaticInterface>();
	    }


        /// <summary>
        /// Method used to load new scene. Also generates or sets active automatic UIs
        /// </summary>
        /// <param name="SceneName">String used later in switch. Specifies current scene</param>
        
        public void ChangeScene(string SceneName)
        {
            switch(SceneName)
            {

                //TODO: When changing the scene map is deactivated but then the building stops gathering while on the other map
                //Fixed the problem with stop of gathering at all - it was somehow connected with min and max staff required - for more details check GatheringBuilding
                case "GlobalMap":
                    if (_firstOpen == true) //If it's the first open of global map it creates an instance of global map UI
                    {
                        SceneManager.LoadScene("GlobalMapUI");
                        DontDestroyOnLoad(Root);
                        DontDestroyOnLoad(Controllers.GameController);
                        LocalMapCanvas.active = false; //Deactivating old canvas
                        Controllers.GameController.gameObject.transform.FindChild("City Controller").gameObject.transform.FindChild("Map").gameObject.active = false;
                        MainCamera = Root.GetComponentInChildren<Camera>();
                        GlobalMapCanvas = Instantiate(Prefabs.Canvas); //Instantiating new canvas
                        GlobalMapCanvas.transform.SetParent(Root.transform, false);
                        GlobalMapCanvas.AddComponent<GlobalMapInterface>();
                        _firstOpen = false;
                    }
                    else //If the global map is opened for another time it just loads scene and sets active global map canvas
                    {
                        SceneManager.LoadScene("GlobalMapUI");
                        DontDestroyOnLoad(Root);
                        DontDestroyOnLoad(Controllers.GameController);
                        Controllers.GameController.gameObject.transform.FindChild("City Controller").gameObject.transform.FindChild("Map").gameObject.active = false;
                        LocalMapCanvas.active = false; //Deactivating old canvas
                        GlobalMapCanvas.active = true; //Activating new canvas
                    }
                    break;
                case "LocalMap": //Only used to load local map scene and set active local map canvas - because it's instantiated at the start of the game
                    SceneManager.LoadScene("AutomatedUI");
                    DontDestroyOnLoad(Root);
                    DontDestroyOnLoad(Controllers.GameController);
                    Controllers.GameController.gameObject.transform.FindChild("City Controller").gameObject.transform.FindChild("Map").gameObject.active = true;
                    GlobalMapCanvas.active = false; //Deactivating old canvas
                    LocalMapCanvas.active = true; //Activating new canvas
                    break;
            }
        }

	    public void Update()
        {
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