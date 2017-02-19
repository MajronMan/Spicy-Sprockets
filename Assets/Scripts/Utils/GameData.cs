using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Buildings;
using Assets.Scripts.Res;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Assets.Scripts.Utils {
    /// <summary>
    /// Data that's constant through the entire game
    /// </summary>
    public class GameData {
        public List<ResourceType> ResourceTypes;
        private Dictionary<string, ResourceType> _resourceTypesByName;

        public List<Commodity> InitialCommodities;

        private List<Type> _buildingTypes;
        public Dictionary<Type, Sprite> BuildingData = new Dictionary<Type, Sprite>();
        public Dictionary<Type, List<Commodity>> BuildingCosts;

        public void Load() {
            JToken gameData = JToken.Parse(File.ReadAllText(Application.streamingAssetsPath + "/Data/GameData.json"));

            ResourceTypes = LoadArray(gameData["ResourceTypes"], LoadResourceType);
            _resourceTypesByName = ResourceTypes.ToDictionary(type => type.Name, type => type);

            InitialCommodities = LoadArray(gameData["InitialResources"], LoadResource);

            _buildingTypes = gameData["BuildingTypes"]
                .Values<string>()
                .Select(name => FindType(typeof(Building), name))
                .ToList();

            const string buildingPath = "Graphics/Buildings/";
            BuildingData = _buildingTypes.ToDictionary(t => t, t => Resources.Load<Sprite>(buildingPath + t.Name));

            BuildingCosts = ((JObject) gameData["BuildingCosts"]).Properties()
                .ToDictionary(p => FindType(typeof(Building), p.Name),
                    p => p.Value.Children().Select(LoadResource).ToList());
        }

        private List<T> LoadArray<T>(JToken array, Func<JToken, T> elementLoader) {
            return array.Children().Select(elementLoader).ToList();
        }

        private ResourceType LoadResourceType(JToken token) {
            var name = token.Value<string>("Name");
            var mass = token.Value<int>("Mass");
            var volume = token.Value<int>("Volume");
            var defaultPrice = token.Value<int>("DefaultPrice");
            return new ResourceType(name, mass, volume, defaultPrice);
        }

        private Commodity LoadResource(JToken token) {
            var type = _resourceTypesByName[token.Value<string>("Type")];
            var amount = token.Value<int>("Amount");
            return new Commodity(type, amount);
        }

        private Type FindType(Type namespaceHint, string name) {
            return Type.GetType(namespaceHint.Namespace + "." + name);
        }
    }
}