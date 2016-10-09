using System.Collections.Generic;
using Assets.Scripts.Buildings;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Interface;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.Building.Editor.Buildings
{
    public class BuildingManagerTestCase {
        private GameObject _gameObject;
        private BuildingManager _buildingManager;

        private void SetUp()
        {
            _gameObject = new GameObject("Tester", typeof(BuildingManager), typeof(Map));
            _buildingManager = _gameObject.GetComponent<BuildingManager>();
            _buildingManager.SetMapInstance(_gameObject.GetComponent<Map>());
        }

        [Test]
        public void TestBuildAddsGivenTypeToBuiltList()
        {
            SetUp();
            var type = typeof(ProductionBuilding);
            _buildingManager.Build(type, Vector3.zero);
            Assert.AreEqual(_buildingManager.Built.Count, 1);
            Assert.AreEqual(_buildingManager.Built[0].GetType(), type);
        }
        [Test]
        public void TestBuildingIsAtGivenPoint([Values(1, 10, 100)] int x, [Values(5, 10, 15)] int y, [Values(-13, -123, -58)] int z)
        {
            SetUp();
            var v = new Vector3(x, y, z);
            var type = typeof(ProductionBuilding);
            _buildingManager.Build(type, v);
            var expectedPosition = Camera.main.ScreenToWorldPoint(v);
            expectedPosition.z = 0;
            Assert.AreEqual(_buildingManager.Built[0].transform.position, expectedPosition);
        }
        [Test]
        public void TestBuildingManagerLoadsAvailableBuildings()
        {
            SetUp();
            _buildingManager.Start(); //need to call that since it waits until first frame and the test ends sooner
            //will make more sense once it loads from a file
            var expected = new Dictionary<string, System.Type>() {
                { "Production Building", typeof(ProductionBuilding) },
                { "Storage Building", typeof(StorageBuilding) }
            };
            CollectionAssert.AreEquivalent(_buildingManager.AvailableBuildings, expected);
        }
    }
}
