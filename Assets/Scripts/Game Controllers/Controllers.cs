using Assets.Scripts.Game_Controllers.Game_Modes;
using Assets.Scripts.Interface;
using Assets.Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers
{
    public sealed class Controllers
    {
        private readonly GameController _gameController;
        private static readonly GameData Data = new GameData();
        private static readonly Controllers Instance = new Controllers();

        private Controllers()
        {
            Debug.Log("costam");
            var gameObject = new GameObject("Game Controller", typeof(GameController));
            _gameController = gameObject.GetComponent<GameController>();
            _gameController.MapPrefab = AssetDatabase.LoadAssetAtPath(@"Assets\Prefabs\Map.prefab", typeof(Map)) as Map;
            _gameController.BeginGame();
            _gameController.GetCurrentCity().MyInfo.LoadInitialResources(Data.ResourceTypes);
        }

        public static GameController GameController
        {
            get { return Instance._gameController; }
        }

        public static CityController CurrentCityController
        {
            get { return Instance._gameController.GetCurrentCity(); }
        }

        public static BuildingManager CurrentBuildingManager
        {
            get { return Instance._gameController.GetCurrentCity().GetBuildingManager(); }
        }

        public static IGameMode CurrentGameMode
        {
            get { return Instance._gameController.GetGameMode(); }
        }

        public static Info CurrentInfo
        {
            get { return CurrentCityController.MyInfo; }
        }

        public static GameData ConstantData
        {
            get { return Data; }
        }
    }
}
