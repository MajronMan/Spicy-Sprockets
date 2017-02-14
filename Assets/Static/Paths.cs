using System.IO;

namespace Assets.Static {
    /// <summary>
    /// Container with paths to prefabs, so that if one prefab is renamed, we just change its path here instead of searching for usages
    /// </summary>
    public static class PrefabPaths {
        public static string Prefabs {
            get { return @"Prefabs/"; }
        }

        private static string _root = @"Root";
        private static string _map = @"Map";
        private static string _canvas = @"CanvasPrefab";
        private static string _building = @"Building";
        private static string _panel = @"GenericPanel";
        private static string _cogwheelButton = @"CogwheelButton";
        private static string _verticalGroupPanel = @"VerticalGroupPanel";
        private static string _horizontalGroupPanel = @"HorizontalGroupPanel";
        private static string _notRotatingText = @"NotRotatingText";
        private static string _casualButton = @"CasualButton";
        private static string _resourceIndicator = @"ResourceIndicator";
        private static string _gridGroupPanel = @"GridGroupPanel";
        private static string _exitButton = @"ExitButton";
        private static string _buildButton = @"BuildButton";
        private static string _popup = @"Popup";
        private static string _exitablePanel = @"ExitablePanel";
        private static string _tradeButton = @"TradeButton";
        private static string _slider = @"Slider";
        private static string _textButton = @"TextButton";
        private static string _dialoguePanel = @"DialoguePanel";
        private static string _eventPanel = @"EventPanel";
        private static string _optionButton = @"OptionButton";

        /// <summary>
        /// Path of base game object with event system and camera
        /// </summary>
        public static string Root {
            get { return Prefabs + _root; }
        }

        /// <summary>
        /// path of main map prefab
        /// </summary>
        public static string Map {
            get { return Prefabs + _map; }
        }

        /// <summary>
        /// Path of the base of UI
        /// </summary>
        public static string Canvas {
            get { return Prefabs + _canvas; }
        }

        /// <summary>
        /// Path of generic building prefab
        /// </summary>
        public static string Building {
            get { return Prefabs + _building; }
        }

        /// <summary>
        /// Path of a basic UI panel
        /// </summary>
        public static string Panel {
            get { return Prefabs + _panel; }
        }

        public static string CogwheelButton {
            get { return Prefabs + _cogwheelButton; }
        }

        public static string VerticalGroupPanel {
            get { return Prefabs + _verticalGroupPanel; }
        }

        public static string HorizontalGroupPanel {
            get { return Prefabs + _horizontalGroupPanel; }
        }

        public static string NotRotatingText {
            get { return Prefabs + _notRotatingText; }
        }

        public static string CasualButton {
            get { return Prefabs + _casualButton; }
        }

        public static string ResourceIndicator {
            get { return Prefabs + _resourceIndicator; }
        }

        public static string GridGroupPanel {
            get { return Prefabs + _gridGroupPanel; }
        }

        public static string ExitButton {
            get { return Prefabs + _exitButton; }
        }

        public static string Popup {
            get { return Prefabs + _popup; }
        }
        public static string BuildButton { get {return Prefabs + _buildButton;} }

        public static string ExitablePanel { get {return Prefabs + _exitablePanel;} }

        public static string TradeButton { get { return Prefabs + _tradeButton; } }

        public static string Slider { get { return Prefabs + _slider; } }

        public static string TextButton { get { return Prefabs + _textButton;  } }

        public static string DialoguePanel { get { return Prefabs + _dialoguePanel; } }

        public static string EventPanel { get { return Prefabs + _eventPanel; } }

        public static string OptionButton { get { return Prefabs + _optionButton; } }
    }

    /// <summary>
    /// Container with paths to sprites, so that if one sprite is renamed, we just change its path here instead of searching for usages
    /// </summary>
    public static class GraphicsPaths {
        public static string Graphics = @"Graphics/";
        public static string InterfaceGraphics = Graphics + @"Interface/";
        public static string ResourcePoolGraphics = Graphics + @"Pools/";
        public static string BuildingsGraphics = Graphics + @"Buildings/";
        private static string _food = @"Food";
        private static string _coal = @"Coal";
        private static string _metal = @"Metal";
        private static string _wood = @"Wood";
        private static string _stone = @"Stone";
        private static string _mineral = @"Mineral";

        public static string Food {
            get { return InterfaceGraphics + _food; }
        }

        public static string Coal {
            get { return InterfaceGraphics + _coal; }
        }

        public static string Metal {
            get { return InterfaceGraphics + _metal; }
        }

        public static string Wood {
            get { return InterfaceGraphics + _wood; }
        }

        public static string Stone {
            get { return InterfaceGraphics + _stone; }
        }

        public static string Mineral {
            get { return InterfaceGraphics + _mineral; }
        }

        public static string[] ResourcesSprites = {Food, Coal, Metal, Wood, Stone, Mineral};
    }
}