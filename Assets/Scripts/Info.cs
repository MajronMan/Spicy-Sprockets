using System.Collections.Generic;

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