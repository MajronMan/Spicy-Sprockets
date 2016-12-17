using Newtonsoft.Json;

namespace Assets.Scripts.Res {
    /// <summary>
    /// Provides info like mass, volume, about some resource type, e.g. wood, stone, etc.
    /// </summary>
    public class ResourceType {
        [JsonProperty] public readonly string Name;
        [JsonProperty] public readonly int Mass;
        [JsonProperty] public readonly int Volume;
        //Default price should definitely go somewhere else
        [JsonProperty] public readonly int DefaultPrice;

        public ResourceType(string name, int mass, int volume, int defaultPrice) {
            Name = name;
            Mass = mass;
            Volume = volume;
            DefaultPrice = defaultPrice;
        }

        public override string ToString() {
            return Name;
        }

        public string InterfaceSpriteName()
        {
            return Name + ".png";
        }

        public string PoolSpriteName()
        {
            return Name + "Pool.png";
        }

        protected bool Equals(ResourceType other) {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ResourceType) obj);
        }

        public override int GetHashCode() {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(ResourceType left, ResourceType right) {
            return Equals(left, right);
        }

        public static bool operator !=(ResourceType left, ResourceType right) {
            return !Equals(left, right);
        }
    }
}