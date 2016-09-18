using System.Collections.Generic;
using Assets.Scripts.Buildings;
using Assets.Scripts.Resources;

namespace Assets.Scripts
{
    public class Info
    {
        public Dictionary<string, Resource> MyResources;
        public int Population;
        public int Money;
        private readonly BuildingManager _buildingManagerInstance;

        public Info(BuildingManager instance)
        {
            _buildingManagerInstance = instance;
        }

        public List<Building> Buildings
        {
            get
            {
                return _buildingManagerInstance.GetBuilt();
            }
        }
    }
}