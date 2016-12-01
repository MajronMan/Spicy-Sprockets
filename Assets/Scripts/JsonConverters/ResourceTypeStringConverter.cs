using System;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Newtonsoft.Json;

namespace Assets.Scripts.JsonConverters {
    public class ResourceTypeStringConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            ResourceType rt = (ResourceType) value;
            writer.WriteValue(rt.Name);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
            string typeName = (string) reader.Value;

            return Controllers.ConstantData.SerializationHelper.ResourceTypesByName[typeName];
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(ResourceType);
        }
    }
}