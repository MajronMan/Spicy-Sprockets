using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

public class BuildingManagerTestCase {
    GameObject go;
    BuildingManager bm;

    private void SetUp()
    {
        go = new GameObject("Tester", typeof(BuildingManager), typeof(BuildingStub), typeof(Map));
        bm = go.GetComponent<BuildingManager>();
        bm.buildingStub = go.GetComponent<BuildingStub>();
        bm.SetMapInstance(go.GetComponent<Map>());
    }

    [Test]
	public void TestBuildAddsGivenTypeToBuiltList()
	{
        SetUp();
        var type = typeof(ProductionBuilding);
        bm.Build(type, Vector3.zero);
        Assert.AreEqual(bm.Built.Count, 1);
        Assert.AreEqual(bm.Built[0].GetType(), type);
	}
    [Test]
    public void TestBuildingIsAtGivenPoint([Values(1, 10, 100)] int x, [Values(5, 10, 15)] int y, [Values(-13, -123, -58)] int z)
    {
        SetUp();
        var v = new Vector3(x, y, z);
        var type = typeof(ProductionBuilding);
        bm.Build(type, v);
        var expectedPosition = Camera.main.ScreenToWorldPoint(v);
        Assert.AreEqual(bm.Built[0].transform.position, expectedPosition);
    }
    [Test]
    public void TestBuildingManagerLoadsAvailableBuildings()
    {
        SetUp();
        bm.Start(); //need to call that since it waits until first frame and the test ends sooner
        var expected = new Dictionary<string, System.Type>() {
            { "Production Building", typeof(ProductionBuilding) }
        };
        CollectionAssert.AreEquivalent(bm.availableBuildings, expected);
    }
}
