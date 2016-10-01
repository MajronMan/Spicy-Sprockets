using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;

public class BuildingManagerTestCase {

	[Test]
	public void TestBuildAddsGivenTypeToBuiltList()
	{
        var go = new GameObject();
        go.AddComponent<BuildingManager>();
        go.AddComponent<BuildingStub>();
        go.AddComponent<Map>();
        var bm = go.GetComponent<BuildingManager>();
        bm.buildingStub = go.GetComponent<BuildingStub>();
        bm.SetMapInstance(go.GetComponent<Map>());
        var type = typeof(ProductionBuilding);
        bm.Build(type, Vector3.zero);
        Assert.AreEqual(bm.Built.Count, 1);
        Assert.AreEqual(bm.Built[0].GetType(), type);

	}
}
