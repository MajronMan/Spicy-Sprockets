using Assets.Scripts.Buildings.Components;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// A building that provides housing and increases population limit
    /// </summary>
    public sealed class ResidentialBuilding : Building, IHouse {
        private IHouse _house;

        public void Awake() {
            _house = gameObject.AddComponent<House>();
        }

        public override void Start() {
            base.Start();
        }

        public int PeopleLimitIncrease {
            get { return _house.PeopleLimitIncrease; }
        }
    }
}