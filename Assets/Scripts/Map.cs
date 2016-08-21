using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public Cell cellPrefab;
    public Building buildingPrefab;
    private Cell [,] cells;
    private Cell highlighted;
    public IntVector2 size;
    public Material m3;
    public void Generate()
    {
        cells = new Cell[size.x, size.z];
        for (int i = 0; i < size.x; i++)
            for (int j = 0; j < size.z; j++)
                cells[i, j] = CreateCell(i, j);
    }
    private Cell CreateCell(int x, int z)
    {
        
        Cell newCell = Instantiate < Cell >(cellPrefab);
        if (x % 2 == 0)
            newCell.m1 = m3;
        newCell.name = x + ", " + z;
        newCell.coords = new IntVector2(x, z);
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(10*x, transform.position.y, 10*z);
        return newCell;
    }
	// Use this for initialization
	void Start () {
        Generate();
	}

    void HighlightCell(RaycastHit hit)
    {
        foreach (Cell cell in cells)
        {
            if (hit.collider == cell.GetComponentInChildren<MeshCollider>())
            {
                if(highlighted != null) 
                    highlighted.SwitchHighlight(false);
                highlighted = cell;
                highlighted.SwitchHighlight();
                return;
            }
        }
    }

    void StopHighlighting()
    {
        if(highlighted != null)
        {
            highlighted.SwitchHighlight(false);
            highlighted = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool p = Physics.Raycast(ray, out hit);
        if (!p)
        {
            StopHighlighting();
            return;
        }

        if (highlighted == null || hit.collider != highlighted.col)
            HighlightCell(hit);
        if (Input.GetMouseButtonDown(0))
            OnMouseClick();
    }
    private void Build()
    {
        Building building = Instantiate < Building >(buildingPrefab);
        building.GetComponentInChildren<TextMesh>().text = highlighted.coords.x + "," + highlighted.coords.z;
        building.transform.parent = highlighted.transform;
        building.transform.localPosition = new Vector3(0,2.5f,0);
        highlighted.building = building;
    }
    void OnMouseClick()
    {
        if (highlighted == null || highlighted.building != null) return;
        Build();
    }
}
