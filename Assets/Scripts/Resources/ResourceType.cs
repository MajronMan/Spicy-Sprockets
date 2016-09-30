using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;

namespace Assets.Scripts.Resources
{
    public class ResourceType
    {
		public Dictionary<string, Dictionary<string, string>> Data;

		public ResourceType(IEnumerable<XElement> elements)
		{
			Data = new Dictionary<string, Dictionary<string, string>>();
			foreach (XElement el in elements) {
				string key = el.Name.ToString();
				Data.Add (key, GetAttributes (el));
			}
		}
			
		public Dictionary<string, string> GetData(string type){
			return Data [type];
		}
		private Dictionary<string, string> GetAttributes(XElement element){
			Dictionary <string, string> dict = new Dictionary<string, string> ();
			foreach (var atr in element.Attributes()) {
				dict.Add (atr.Name.ToString(), atr.Value);
			}
			return dict;
		}
    }
}
