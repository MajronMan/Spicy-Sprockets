using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Res;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Utils {
    /// <summary>
    /// Data that's constant through the entire game
    /// </summary>
    public class GameData {
        //is a mess, needs refactor
        public Dictionary<ResourceType, Sprite> SourceSprites = new Dictionary<ResourceType, Sprite>();

        public List<ResourceType> ResourceTypes;
        public List<Resource> InitialResources;

        public Dictionary<Type, Sprite> BuildingData = new Dictionary<Type, Sprite>();
        public Dictionary<Type, List<Resource>> BuildingCosts;

        public GameData() {
            ResourceTypes =
                JsonConvert.DeserializeObject<List<ResourceType>>(
                    File.ReadAllText(Application.streamingAssetsPath + "/Data/ResourceTypes.json"));

            InitialResources =
                JsonConvert.DeserializeObject<List<Resource>>(
                    File.ReadAllText(Application.streamingAssetsPath + "/Data/InitialResources.json"));

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

            //            string path = Application.dataPath + "/GameData.json";
            //            File.WriteAllText(path,
            //                JsonConvert.SerializeObject(Controllers.Data, Formatting.Indented, new JsonSerializerSettings() {
            //                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            //                    TypeNameHandling = TypeNameHandling.Auto,
            //                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            //                }));
            //            Debug.Break();

            ResourceTypes.ForEach(resource => {
                var sourcePath = "Graphics/Sources/" + resource.Name + "Source";
                SourceSprites.Add(resource, Resources.Load<Sprite>(sourcePath));
            });
        }
    }
}