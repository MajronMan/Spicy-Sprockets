using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public Cell cellPrefab;
    public Building buildingPrefab;
    private Cell [,] cells;
    public IntVector2 size;
    public void Generate()
    {
        cells = new Cell[size.x, size.y];
        for (int i = 0; i < size.x; i++)
            for (int j = 0; j < size.y; j++)
                cells[i, j] = CreateCell(i, j);
    }
    private Cell CreateCell(int x, int y)
    {
        Cell newCell = Instantiate < Cell >(cellPrefab);
        newCell.name = x + ", " +y;
        newCell.coords = new IntVector2(x, y);
        newCell.transform.SetParent(transform);
        newCell.transform.localPosition = new Vector3(x, y, 1);
        return newCell;
    }
	// Use this for initialization
	void Start () {
        Generate();
        Physics.queriesHitTriggers = true;
	}
    void Update()
    {
    
    }
}
