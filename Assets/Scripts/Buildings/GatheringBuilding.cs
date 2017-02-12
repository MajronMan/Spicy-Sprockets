//using Assets.Scripts.Buildings.Components;
//using Assets.Scripts.Game_Controllers;
//using Assets.Scripts.Utils;
//using UnityEngine;
//
//namespace Assets.Scripts.Buildings {
//    /// <summary>
//    /// General class of buildings that gather resources from environment like coal, wood etc.
//    /// </summary>
//    public abstract class GatheringBuilding : Building {
//        //they should be private, but left protected for compatibility with specific subtypes
//        protected IResourceGathering _resourceGathering;
//        protected IStaffEmployment _staffEmployment;
//
//        //maybe someone will change it later, for now I think it looks pretty
//        private BuildingPanel _panel;
//
//        public void Awake() {
//            _resourceGathering = gameObject.AddComponent<ResourceGathering>();
//            _staffEmployment = gameObject.AddComponent<StaffEmployment>();
//        }
//
//        public override void Start() {
//            base.Start();
//            //Remember ResourcePools that are in range, they will be used by IResourceGathering
//            foreach (var pool in Controllers.CurrentCityController.MapInstance.Pools) {
//                if (Vector3.Distance(pool.transform.position, transform.position) < pool.Radius
//                    && pool.Resource == _resourceGathering.GatheredResource) {
//                    _resourceGathering.Sources.Add(pool);
//                }
//            }
//            //employing staff
//            _staffEmployment.Staff = _staffEmployment.MinStaff;
//        }
//
//        //will gather only if manned
//        public void Update() {
//            if (_resourceGathering.CanStartGathering() && _staffEmployment.IsEnoughStaff())
//                StartCoroutine(_resourceGathering.Gather());
//        }
//    }
//}