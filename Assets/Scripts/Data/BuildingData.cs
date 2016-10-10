using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class BuildingData{

	[XmlAttribute("Name")]
	public string name;

	[XmlElement("PosX")]
	public float posX;

	[XmlElement("PosY")]
	public float posY;

	[XmlElement("PosZ")]
	public float posZ;


	public static BuildingData newData(Building building){
		BuildingData data = new BuildingData();
		data.name = "1";
		Vector3 pos = building.transform.position;
		data.posX = pos.x;
		data.posY = pos.y;
		data.posZ = pos.z;
		return data;
	}
}