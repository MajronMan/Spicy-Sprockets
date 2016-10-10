using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Assets.Scripts.Resources;

namespace Assets.Scripts.Utils
{
    public class Info {
        public Dictionary<string, Resource> Resources = new Dictionary<string, Resource>();
        public Population ThePeople;
        public Money MyMoney = new Money();

        public void LoadInitialResources(Dictionary<string, Dictionary<string, string>> resourceTypes)
        {
            foreach (var type in resourceTypes.Keys)
            {
                var res = new Resource(type, int.Parse(resourceTypes[type]["initial"]));
                Resources.Add(type, res);
            }
        }

        public Resource this[string key]
        {
            get { return Resources[key]; }
            set { Resources[key] = value; }
        }
    }
}
