using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Resources;
using System.IO;
using System;
using System.Xml.Linq;

public class Info {
	public ResourceType ResourceTypes;
	public List<Resource> Resources;

	public Info(){
		string path = Directory.GetCurrentDirectory()+@"\Assets\Data\ResourceTypes.xml";
		XDocument doc = XDocument.Load (path);
		ResourceTypes = new ResourceType (doc.Root.Elements ());
	}
}
