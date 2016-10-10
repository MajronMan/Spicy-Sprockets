using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using Assets.Scripts.Buildings;
using Assets.Scripts.Data;

public class SaveData {

	public static BuildingContainer buildingContainer = new BuildingContainer();

	public delegate void SerializeAction();
//	public static event SerializeAction OnLoaded;
//	public static event SerializeAction OnBeforeSave;


	public static void Save(string path, BuildingContainer buidlings)
	{
//		OnBeforeSave();
		SaveBuildings(path, buidlings);
		ClearBuildings();
	}

	public static void Load(string path)
	{
		buildingContainer = LoadBuildings(path);
	}

	public static void AddBuildingData(Building building)
	{
		BuildingData data = BuildingData.NewData (building);
		buildingContainer.bulidings.Add(data);
	}

	public static void ClearBuildings()
	{
		buildingContainer.bulidings.Clear();
	}

	private static void SaveBuildings(string path, BuildingContainer buildings)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(BuildingContainer));
		FileStream stream = new FileStream(path, FileMode.Create);
		serializer.Serialize(stream, buildings);
		stream.Close();
	}

	private static BuildingContainer LoadBuildings (string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(BuildingContainer));
		FileStream stream = new FileStream(path, FileMode.Open);
		BuildingContainer buildings = serializer.Deserialize(stream) as BuildingContainer;
		stream.Close();
		return buildings;
	}

}
