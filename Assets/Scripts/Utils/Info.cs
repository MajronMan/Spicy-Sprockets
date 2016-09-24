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

	public Info(){
		string path = Directory.GetCurrentDirectory()+@"\Assets\Data\ResourceTypes.xml";
		XDocument doc = XDocument.Load (path);
		ResourceTypes = new ResourceType (doc.Root.Elements ());
		var data = ResourceTypes.Data;
		foreach (var key in data.Keys) {
			Resource res = new Resource (key, Int32.Parse(data [key] ["initial"]), Quality.Lux, this); 
			Resources.Add (key, res);
		}
	}
}
