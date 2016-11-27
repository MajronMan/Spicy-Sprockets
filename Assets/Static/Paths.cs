namespace Assets.Static
{
    /// <summary>
    /// Container with paths to prefabs, so that if one prefab is renamed, we just change its path here instead of searching for usages
    /// </summary>
    public static class PrefabPaths
    {
        public static string Prefabs { get { return "Assets/Prefabs/"; } }

        private static string _root = "Root.prefab";
        private static string _map = "Map.prefab";
        private static string _canvas = "CanvasPrefab.prefab";
        private static string _building = "Building.prefab";
        private static string _panel = "GenericPanel.prefab";
        private static string _cogwheelButton = "CogwheelButton.prefab";
        private static string _mainPanel = "MainPanel.prefab";
        private static string _notRotatingText = "NotRotatingText.prefab";

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

        public static string MainPanel { get { return Prefabs + _mainPanel; } }

        public static string NotRotatingText { get { return Prefabs + _notRotatingText; } }
    }

    /// <summary>
    /// Container with paths to sprites, so that if one sprite is renamed, we just change its path here instead of searching for usages
    /// </summary>
    public static class GraphicsPaths
    {
        public static string Graphics = "Assets/Graphics/";
        

    }
}
