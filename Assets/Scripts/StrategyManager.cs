using UnityEngine;
using System.Collections;

public class StrategyManager : MonoBehaviour {
    public Map mapPrefab;
    private Map mapInstance;


    private void Start()
    {
        BeginGame();
    }

    private void BeginGame()
    {
        mapInstance = Instantiate(mapPrefab) as Map;
        mapInstance.transform.SetParent(transform);
        mapInstance.name = "Map Instance";
        
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
}
