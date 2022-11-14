using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    private GridDisplay _gridDisplay;
    private Grid _grid;
    private int _gridWidth = 20;
    private int _gridHeight = 10;
    private float _cellSize = 1f;

    private bool _shouldGetPos = false;

    [SerializeField] GameObject Pointer;

    [SerializeField] Material LineMaterial;

    void Start()
    {
        _gridDisplay = BuildGridDisplay(_gridWidth, _gridHeight, _cellSize, this.transform.position, LineMaterial);
        _grid = BuildGrid(_gridWidth, _gridHeight, _cellSize, this.transform.position);
    }

    void Update()
    {

        
    }

    public (Vector3, bool) CanBePlaced(Vector3 position, int widthInUnits, int heightInUnits)
    {
        return _grid.CanBePlaced(position, widthInUnits, heightInUnits);
    }

    private Grid BuildGrid(int width, int height, float cellSize, Vector3 origin)
    {
        return new Grid(width, height, cellSize, origin);
    }

    private GridDisplay BuildGridDisplay(int width, int height, float cellSize, Vector3 origin, Material material)
    {
        GameObject emptyObject = new GameObject();
        emptyObject.transform.parent = this.transform;
        emptyObject.name = "GridLines";

        GridDisplay newGrid = new GridDisplay(width, height, cellSize, origin, material);
        List<GameObject> gridLines = newGrid.AddGridLines();

        for (int i = 0; i < gridLines.Count; i ++)
        {
            gridLines[i].transform.parent = emptyObject.transform;
        }

        return newGrid;
    }
}
