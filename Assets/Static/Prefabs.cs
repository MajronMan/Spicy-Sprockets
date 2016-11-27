using System.Collections.Generic;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Static
{
    public class Prefabs
    {
        private static GameObject _root;
        private static GameObject _map;
        private static GameObject _canvas;
        private static GameObject _building;
        private static GameObject _panel;
        private static GameObject _cogwheelButton;
        private static GameObject _mainPanel;
        private static GameObject _notRotatingText;

        /// <summary>
        /// Base game object with event system and camera
        /// </summary>
        public static GameObject Root { get { return _root ?? (_root = Loader.LoadPrefab(PrefabPaths.Root)); }}

        /// <summary>
        /// Main map prefab
        /// </summary>
        public static GameObject Map { get { return _map ?? (_map = Loader.LoadPrefab(PrefabPaths.Map)); } }

        /// <summary>
        /// Base of UI
        /// </summary>
        public static GameObject Canvas { get { return _canvas ?? (_canvas = Loader.LoadPrefab(PrefabPaths.Canvas)); } }

        /// <summary>
        /// Generic building prefab
        /// </summary>
        public static GameObject Building { get { return _building ?? (_building = Loader.LoadPrefab(PrefabPaths.Building)); } }

        /// <summary>
        /// Basic UI panel
        /// </summary>
        public static GameObject Panel { get { return _panel ?? (_panel = Loader.LoadPrefab(PrefabPaths.Panel)); } }

        public static GameObject CogwheelButton { get { return _cogwheelButton ?? (_cogwheelButton = Loader.LoadPrefab(PrefabPaths.CogwheelButton)); } }

        public static GameObject MainPanel { get { return _mainPanel ?? (_mainPanel = Loader.LoadPrefab(PrefabPaths.MainPanel)); } }

        public static GameObject NotRotatingText { get { return _notRotatingText ?? (_notRotatingText = Loader.LoadPrefab(PrefabPaths.NotRotatingText)); } }

        public static Dictionary<string, GameObject> PathsToObjects = new Dictionary<string, GameObject>()
        {
            { PrefabPaths.Root, Root},
            { PrefabPaths.Map, Map},
            { PrefabPaths.Canvas, Canvas},
            { PrefabPaths.Building, Building},
            { PrefabPaths.Panel, Panel},
            { PrefabPaths.CogwheelButton, CogwheelButton },
            { PrefabPaths.MainPanel, MainPanel },
            { PrefabPaths.NotRotatingText, NotRotatingText }
        };
    }
}
