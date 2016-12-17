using System.IO;

namespace Assets.Static
{
    /// <summary>
    /// Container with paths to prefabs, so that if one prefab is renamed, we just change its path here instead of searching for usages
    /// </summary>
    public static class PrefabPaths
    {
        public static string Prefabs { get { return "Assets/Resources/Prefabs/"; } }

        private static string _root = "Root.prefab";
        private static string _map = "Map.prefab";
        private static string _canvas = "CanvasPrefab.prefab";
        private static string _building = "Building.prefab";
        private static string _panel = "GenericPanel.prefab";
        private static string _cogwheelButton = "CogwheelButton.prefab";
        private static string _verticalGroupPanel = "VerticalGroupPanel.prefab";
        private static string _horizontalGroupPanel = "HorizontalGroupPanel.prefab";
        private static string _notRotatingText = "NotRotatingText.prefab";
        private static string _casualButton = "CasualButton.prefab";
        private static string _resourceIndicator = "ResourceIndicator.prefab";
        private static string _gridGroupPanel = "GridGroupPanel.prefab";

        /// <summary>
        /// Path of base game object with event system and camera
        /// </summary>
        public static string Root { get { return Prefabs + _root;} }
        /// <summary>
        /// path of main map prefab
        /// </summary>
        public static string Map  { get { return Prefabs + _map; } }
        /// <summary>
        /// Path of the base of UI
        /// </summary>
        public static string Canvas { get { return Prefabs + _canvas; } }
        /// <summary>
        /// Path of generic building prefab
        /// </summary>
        public static string Building { get { return Prefabs + _building; } }
        /// <summary>
        /// Path of a basic UI panel
        /// </summary>
        public static string Panel { get { return Prefabs + _panel;} }

        public static string CogwheelButton { get { return Prefabs + _cogwheelButton;} }

        public static string VerticalGroupPanel { get { return Prefabs + _verticalGroupPanel; } }

        public static string HorizontalGroupPanel { get { return Prefabs + _horizontalGroupPanel; } }

        public static string NotRotatingText { get { return Prefabs + _notRotatingText; } }

        public static string CasualButton { get { return Prefabs + _casualButton; } }

        public static string ResourceIndicator { get { return Prefabs + _resourceIndicator; } }

        public static string GridGroupPanel { get { return Prefabs + _gridGroupPanel; } }
    }

    /// <summary>
    /// Container with paths to sprites, so that if one sprite is renamed, we just change its path here instead of searching for usages
    /// </summary>
    public static class GraphicsPaths
    {
        public static string Graphics = "Assets/Resources/Graphics/";
        public static string InterfaceGraphics = Graphics + "Interface/";
        public static string ResourcePoolGraphics = Graphics + "Pools/";
        private static string _food = "Food.png";
        private static string _coal = "Coal.png";
        private static string _metal = "Metal.png";
        private static string _wood = "Wood.png";
        private static string _stone= "Stone.png";
        private static string _mineral = "Mineral.png";

        public static string Food { get { return InterfaceGraphics + _food; } }
        public static string Coal { get { return InterfaceGraphics + _coal; } }
        public static string Metal { get { return InterfaceGraphics + _metal; } }
        public static string Wood { get { return InterfaceGraphics + _wood; } }
        public static string Stone { get { return InterfaceGraphics + _stone; } }
        public static string Mineral { get { return InterfaceGraphics + _mineral; } }

        public static string[] ResourcesSprites = {Food, Coal, Metal, Wood, Stone, Mineral};
    }
}
