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
    /// <summary>
    /// Data that's constant through the entire game
    /// </summary>
    public class GameData
    {       
        //is a mess, needs refactor
        public Dictionary<string, Sprite> SourceSprites = new Dictionary<string, Sprite>();
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
            var buildingPath = "Assets/Graphics/Buildings/";
            Type[] buildingTypes = { typeof(ProductionBuilding), typeof(StorageBuilding), typeof(Mine), typeof(LumberMill), typeof(Quarry), typeof(ResidentialBuilding)};
            foreach (var buildingType in buildingTypes)
            {
                var spritePath = buildingPath + buildingType.Name + ".png";
                BuildingData.Add(buildingType, AssetDatabase.LoadAssetAtPath<Sprite>(spritePath));
                BuildingCosts.Add(buildingType,
                    new List<Resource>()
                    {
                        new Resource("wood", 3 + buildingType.GetHashCode()%20),
                        new Resource("stone", 5 + buildingType.GetHashCode()%27)
                    });
            }

            var sources = new List<string>(ResourceTypes.Keys);
            foreach (var source in sources)
            {
                var sourcePath = "Assets/Graphics/Sources/" + source + "Source.png";
                SourceSprites.Add(source, AssetDatabase.LoadAssetAtPath<Sprite>(sourcePath));
            }
        }

        private Dictionary<string, string> GetAttributes(XElement element)
        {
            //not even sure what happened here, but god damn, resharper is smart
            return element.Attributes().ToDictionary(atr => atr.Name.ToString(), atr => atr.Value);
        }
    }
}
