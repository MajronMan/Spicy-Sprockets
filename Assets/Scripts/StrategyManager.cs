using UnityEngine;
using System.Collections;

public class StrategyManager : MonoBehaviour {
    public Map mapPrefab;
    private Map mapInstance=null;
    public BuildingManager buildingManagerPrefab;
    private BuildingManager buildingManagerInstance=null;

    private void Start()
    {
        BeginGame();
    }

    private void BeginGame()
    {
        mapInstance = Instantiate(mapPrefab) as Map;
        mapInstance.transform.SetParent(transform);
        mapInstance.name = "Map Instance";
        buildingManagerInstance = Instantiate(buildingManagerPrefab);
        buildingManagerInstance.transform.SetParent(transform);
        buildingManagerInstance.name = "Building Manager";
        buildingManagerInstance.SetMapInstance(mapInstance);
       
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mapInstance.gameObject);
        BeginGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void mapClicked()
    {
        Debug.Log("korwo");
        if (buildingManagerInstance!=null && buildingManagerInstance.active)
        {
            Debug.Log("Build");
            buildingManagerInstance.Build(Input.mousePosition);
            
        }
    }
}
