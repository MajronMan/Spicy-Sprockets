using System.Collections.Generic;
using System.Xml.Serialization;

namespace Assets.Scripts.Data
{
    [XmlRoot("ActoerCollection")]
    public class BuildingContainer {
        [XmlArray("Buildings")]
        [XmlArrayItem("Building")]
        public List<BuildingData> bulidings = new List<BuildingData>();
    }
}
