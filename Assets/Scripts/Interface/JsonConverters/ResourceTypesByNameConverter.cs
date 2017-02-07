using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts.JsonConverters {
    class ResourceTypesByNameConverter : JsonConverter {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
            JArray jArray = JArray.Load(reader);
            List<ResourceType> deserialized = new List<ResourceType>();
            serializer.Populate(jArray.CreateReader(), deserialized);

            Dictionary<string, ResourceType> byName = deserialized.ToDictionary(type => type.Name);
            Controllers.ConstantData.SerializationHelper.ResourceTypesByName = byName;

            return deserialized;
        }

        public override bool CanWrite {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(List<ResourceType>);
        }
    }
}