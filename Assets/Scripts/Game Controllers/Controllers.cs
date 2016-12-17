using Assets.Scripts.Game_Controllers.Game_Modes;
using Assets.Scripts.Interface;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers {
    /// <summary>
    /// Implements singleton pattern to make controllers available globally, without passing references everywhere
    /// </summary>
    public sealed class Controllers {
        /// <summary>
        /// The controller that defines game behaviour
        /// </summary>
        private GameController _gameController;

        /// <summary>
        /// Data that does not change throughout the game, loaded from file
        /// </summary>
        private static GameData Data;

        /// <summary>
        /// Implementation of singleton
        /// </summary>
        private static Controllers Instance = new Controllers();

        private Controllers() {
            // create a new game object with behaviour defined in GameController script
            var gameObject = new GameObject("Game Controller", typeof(GameController));
            Data = new GameData();
            Data.Load();
            _gameController = gameObject.GetComponent<GameController>();
            _gameController.MapPrefab = Resources.Load<Map>(@"Prefabs\Map");
            _gameController.BeginGame();
            _gameController.GetCurrentCity().MyInfo.LoadInitialResources(Data.InitialResources);
        }

        public static GameController GameController
        {
            get { return Instance._gameController; }
        }

        public static CityController CurrentCityController {
            get { return Instance._gameController.GetCurrentCity(); }
        }

        public static BuildingManager CurrentBuildingManager {
            get { return Instance._gameController.GetCurrentCity().GetBuildingManager(); }
        }

        public static IGameMode CurrentGameMode {
            get { return Instance._gameController.GetGameMode(); }
        }

        public static Info CurrentInfo {
            get { return CurrentCityController.MyInfo; }
        }

        public static GameData ConstantData {
            get { return Data; }
        }

        public static GameObject UIBase
        {
            get { return Instance._gameController.Canvas; }
        }

        public static Camera MainCamera
        {
            get { return Instance._gameController.MainCamera; }
        }
    }
}