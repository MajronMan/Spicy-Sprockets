using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Buildings;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class GameData
    {
        public Dictionary<string, Dictionary<string, string>> ResourceTypes = new Dictionary<string, Dictionary<string, string>>();
        public Dictionary<System.Type, Sprite> BuildingData = new Dictionary<Type, Sprite>();

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
            string cubeFilePath = "Assets/Graphics/Buildings/building.png", tentFilePath = "Assets/Graphics/Buildings/tent.png";
            var cube = AssetDatabase.LoadAssetAtPath<Sprite>(cubeFilePath);
            var tent = AssetDatabase.LoadAssetAtPath<Sprite>(tentFilePath);
            BuildingData.Add(typeof(ProductionBuilding), cube);
            BuildingData.Add(typeof(StorageBuilding), tent);
        }

        private Dictionary<string, string> GetAttributes(XElement element)
        {
            //not even sure what happened here, but god damn, resharper is smart
            return element.Attributes().ToDictionary(atr => atr.Name.ToString(), atr => atr.Value);
        }
    }
}
