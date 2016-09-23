using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot("ActoerCollection")]
public class BuildingContainer {
	[XmlArray("Buildings")]
	[XmlArrayItem("Building")]
	public List<BuildingData> bulidings = new List<BuildingData>();
}
