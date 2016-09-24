using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Resources;
using System.IO;
using System;
using System.Xml.Linq;

public class Info {
	public ResourceType ResourceTypes;
	public Dictionary<string, Resource> Resources = new Dictionary<string, Resource>();
	public Population ThePeople;
	public Money MyMoney = new Money();
	public StrategyManager strategyManager;
	public List<Building> Buildings;

	public Info(){
		strategyManager = GameObject.Find ("Strategy Manager").GetComponent<StrategyManager>();
		//Get path to file with resource type
		string path = Directory.GetCurrentDirectory()+@"\Assets\Data\ResourceTypes.xml";
		XDocument doc = XDocument.Load (path);
		//Constructor loads types from xml
		ResourceTypes = new ResourceType (doc.Root.Elements ());
		//data holds information about resource types
		var data = ResourceTypes.Data;
		foreach (var key in data.Keys) {
			//Create resource instances - arguments mean as follows: name, initial amount, quality, info instance
			Resource res = new Resource (key, Int32.Parse(data [key] ["initial"]), Quality.Lux, this); 
			Resources.Add (key, res);
		}
		Buildings = strategyManager.GetBuildingManager ().Built; 
		//I hope it passes a reference, so it's always current list of buildings
	}
}
