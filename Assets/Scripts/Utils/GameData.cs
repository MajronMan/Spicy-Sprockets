using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Buildings;
using Assets.Scripts.Resources;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class GameData
    {
        public Dictionary<string, Dictionary<string, string>> ResourceTypes = new Dictionary<string, Dictionary<string, string>>();
        public Dictionary<System.Type, Sprite> BuildingData = new Dictionary<Type, Sprite>();
        public Dictionary<System.Type, List<Resource>> BuildingCosts = new Dictionary<Type, List<Resource>>();

        public GameData(string testPath = "")
        {
            //Get path to file with resource type
            var path = testPath == "" ? Directory.GetCurrentDirectory() + @"\Assets\Data\ResourceTypes.xml" : testPath;
            var doc = XDocument.Load(path);
            if (doc.Root == null)
            {
                Debug.Log("GameData no xml doc found");
                return;
            }

            //Constructor loads types from xml
            var elements = doc.Root.Elements();
            foreach (var el in elements)
            {
                var key = el.Name.ToString();
                ResourceTypes.Add(key, GetAttributes(el));
            }

            //later load from XML
            string cubeFilePath = "Assets/Graphics/Buildings/building.png",
                tentFilePath = "Assets/Graphics/Buildings/tent.png",
                mineFilePath = "Assets/Graphics/Buildings/Mine.png",
                lumberFilePath = "Assets/Graphics/Buildings/Lumber_Mill.png";
            var cube = AssetDatabase.LoadAssetAtPath<Sprite>(cubeFilePath);
            var tent = AssetDatabase.LoadAssetAtPath<Sprite>(tentFilePath);
            var mine = AssetDatabase.LoadAssetAtPath<Sprite>(mineFilePath);
            var lumber = AssetDatabase.LoadAssetAtPath<Sprite>(lumberFilePath);
            BuildingData.Add(typeof(ProductionBuilding), cube);
            BuildingData.Add(typeof(StorageBuilding), tent);
            BuildingData.Add(typeof(Mine), mine);
            BuildingData.Add(typeof(LumberMill), lumber);


            BuildingCosts.Add(typeof(StorageBuilding), new List<Resource>() { new Resource("wood", 5), new Resource("stone", 3)});
            BuildingCosts.Add(typeof(ProductionBuilding), new List<Resource>() { new Resource("wood", 10), new Resource("stone", 11) });
            BuildingCosts.Add(typeof(Mine), new List<Resource>() { new Resource("wood", 5), new Resource("stone", 3) });
            BuildingCosts.Add(typeof(LumberMill), new List<Resource>() { new Resource("wood", 5), new Resource("stone", 3) });
        }

        private Dictionary<string, string> GetAttributes(XElement element)
        {
            //not even sure what happened here, but god damn, resharper is smart
            return element.Attributes().ToDictionary(atr => atr.Name.ToString(), atr => atr.Value);
        }
    }
}
