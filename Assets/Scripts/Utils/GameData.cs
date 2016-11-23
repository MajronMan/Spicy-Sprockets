using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Resources;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Utils {
    /// <summary>
    /// Data that's constant through the entire game
    /// </summary>
    public class GameData {
        //is a mess, needs refactor
        public Dictionary<string, Sprite> SourceSprites = new Dictionary<string, Sprite>();

        public Dictionary<string, Dictionary<string, string>> ResourceTypes;

        public Dictionary<System.Type, Sprite> BuildingData = new Dictionary<Type, Sprite>();
        public Dictionary<System.Type, List<Resource>> BuildingCosts;

        public GameData(string testPath = "") {
            ResourceTypes =
                JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(
                    File.ReadAllText(Application.streamingAssetsPath + "/Data/ResourceTypes.json"));

            List<Type> buildingTypes =
                JsonConvert.DeserializeObject<List<Type>>(
                    File.ReadAllText(Application.streamingAssetsPath + "/Data/BuildingTypes.json"));

            var buildingPath = "Graphics/Buildings/";
            foreach (var buildingType in buildingTypes) {
                var spritePath = buildingPath + buildingType.Name;
                BuildingData.Add(buildingType, UnityEngine.Resources.Load<Sprite>(spritePath));
            }
            BuildingCosts =
                JsonConvert.DeserializeObject<Dictionary<Type, List<Resource>>>(
                    File.ReadAllText(Application.streamingAssetsPath + "/Data/BuildingCosts.json"));

            //            File.WriteAllText(Application.dataPath + "/Data/BuildingCosts.json",
            //                JsonConvert.SerializeObject(BuildingCosts, Formatting.Indented));
            //            Debug.Break();

            var sources = new List<string>(ResourceTypes.Keys);
            foreach (var source in sources) {
                var sourcePath = "Graphics/Sources/" + source + "Source";
                SourceSprites.Add(source, UnityEngine.Resources.Load<Sprite>(sourcePath));
            }
        }
    }
}