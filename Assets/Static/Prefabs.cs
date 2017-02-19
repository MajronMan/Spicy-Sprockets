using System.Collections.Generic;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Static {
    public static class Prefabs {
        private static GameObject _root;
        private static GameObject _map;
        private static GameObject _grid;
        private static GameObject _gridLine;
        private static GameObject _canvas;
        private static GameObject _building;
        private static GameObject _panel;
        private static GameObject _cogwheelButton;
        private static GameObject _verticalGroupPanel;
        private static GameObject _horizontalGroupPanel;
        private static GameObject _gridGroupPanel;
        private static GameObject _notRotatingText;
        private static GameObject _casualButton;
        private static GameObject _resourceIndicator;
        private static GameObject _exitButton;
        private static GameObject _buildButton;
        private static GameObject _popup;
        private static GameObject _exitablePanel;
        private static GameObject _tradeButton;
        private static GameObject _slider;
        private static GameObject _textButton;
        private static GameObject _toggle;
        private static GameObject _city;

        /// <summary>
        /// Base game object with event system and camera
        /// </summary>
        public static GameObject Root {
            get { return _root ?? (_root = Loader.LoadPrefab(PrefabPaths.Root)); }
        }

        /// <summary>
        /// Main map prefab
        /// </summary>
        public static GameObject Map {
            get { return _map ?? (_map = Loader.LoadPrefab(PrefabPaths.Map)); }
        }

        public static GameObject Grid {
            get { return _grid ?? (_grid = Loader.LoadPrefab(PrefabPaths.Grid)); }
        }

        /// <summary>
        /// One of the lines that make up grid on local map
        /// </summary>
        public static GameObject GridLine {
            get { return _gridLine ?? (_gridLine = Loader.LoadPrefab(PrefabPaths.GridLine)); }
        }

        /// <summary>
        /// Base of UI
        /// </summary>
        public static GameObject Canvas {
            get { return _canvas ?? (_canvas = Loader.LoadPrefab(PrefabPaths.Canvas)); }
        }

        /// <summary>
        /// Generic building prefab
        /// </summary>
        public static GameObject Building {
            get { return _building ?? (_building = Loader.LoadPrefab(PrefabPaths.Building)); }
        }

        /// <summary>
        /// Basic UI panel
        /// </summary>
        public static GameObject Panel { get { return _panel ?? (_panel = Loader.LoadPrefab(PrefabPaths.Panel)); } }

        public static GameObject CogwheelButton { get { return _cogwheelButton ?? (_cogwheelButton = Loader.LoadPrefab(PrefabPaths.CogwheelButton)); } }

        public static GameObject VerticalGroupPanel { get { return _verticalGroupPanel ?? (_verticalGroupPanel = Loader.LoadPrefab(PrefabPaths.VerticalGroupPanel)); } }

        public static GameObject HorizontalGroupPanel { get { return _horizontalGroupPanel ?? (_horizontalGroupPanel = Loader.LoadPrefab(PrefabPaths.HorizontalGroupPanel)); } }

        public static GameObject NotRotatingText { get { return _notRotatingText ?? (_notRotatingText = Loader.LoadPrefab(PrefabPaths.NotRotatingText)); } }

        public static GameObject CasualButton { get { return _casualButton ?? (_casualButton = Loader.LoadPrefab(PrefabPaths.CasualButton)); } }

        public static GameObject ResourceIndicator { get { return _resourceIndicator ?? (_resourceIndicator = Loader.LoadPrefab(PrefabPaths.ResourceIndicator)); } }

        public static GameObject GridGroupPanel { get { return _gridGroupPanel ?? (_gridGroupPanel = Loader.LoadPrefab(PrefabPaths.GridGroupPanel)); } }

        public static GameObject ExitButton { get { return _exitButton ?? (_exitButton = Loader.LoadPrefab(PrefabPaths.ExitButton)); } }

        public static GameObject BuildButton { get { return _buildButton ?? (_buildButton = Loader.LoadPrefab(PrefabPaths.BuildButton)); } }

        public static GameObject ExitablePanel { get { return _exitablePanel ?? (_exitablePanel = Loader.LoadPrefab(PrefabPaths.ExitablePanel)); } }

        public static GameObject TradeButton { get { return _tradeButton ?? (_tradeButton = Loader.LoadPrefab(PrefabPaths.TradeButton)); } }

        public static GameObject Slider { get { return _slider ?? (_slider = Loader.LoadPrefab(PrefabPaths.Slider)); } }

        public static GameObject TextButton { get { return _textButton ?? (_textButton = Loader.LoadPrefab(PrefabPaths.TextButton)); } }

        public static GameObject Popup { get { return _popup ?? (_popup = Loader.LoadPrefab(PrefabPaths.Popup)); }}

        public static GameObject Toggle { get { return _toggle ?? (_toggle = Loader.LoadPrefab(PrefabPaths.Toggle)); } }

        public static GameObject City { get { return _city ?? (_city = Loader.LoadPrefab(PrefabPaths.City)); } }

        public static Dictionary<string, GameObject> PathsToObjects = new Dictionary<string, GameObject>()
        {
            { PrefabPaths.Root, Root},
            { PrefabPaths.Map, Map},
            { PrefabPaths.Canvas, Canvas},
            { PrefabPaths.Building, Building},
            { PrefabPaths.Panel, Panel},
            { PrefabPaths.CogwheelButton, CogwheelButton },
            { PrefabPaths.VerticalGroupPanel, VerticalGroupPanel },
            { PrefabPaths.HorizontalGroupPanel, HorizontalGroupPanel },
            { PrefabPaths.NotRotatingText, NotRotatingText },
            { PrefabPaths.CasualButton, CasualButton },
            { PrefabPaths.ResourceIndicator, ResourceIndicator },
            { PrefabPaths.GridGroupPanel, GridGroupPanel },
            { PrefabPaths.City, City }
        };
    }
}