using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Game_Controllers;
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

        public bool SufficientResources(List<Resource> costs)
        {
            //no idea again but I hope it works
            return costs.Aggregate(true, (current, resource) => current & Resources[resource.MyType] >= resource);
        }

        public void UseResources(List<Resource> costs)
        {
            foreach (var resource in costs)
            {
                Resources[resource.MyType] -= resource;
            }
        }

        public void BuildingCosts(System.Type buildingType)
        {
            UseResources(Controllers.ConstantData.BuildingCosts[buildingType]);
        }
    }
}
