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

    [SerializeField] GameObject Pointer;

    [SerializeField] Material LineMaterial;

    void Start()
    {
        _gridDisplay = BuildGridDisplay(_gridWidth, _gridHeight, _cellSize, this.transform.position, LineMaterial);
        _grid = BuildGrid(_gridWidth, _gridHeight, _cellSize, this.transform.position);

        var canBePlaced = _grid.CanBePlaced(Pointer.transform.position, 3, 3);
        Debug.Log("Can be placed: " + canBePlaced.Item2 + " at position: X " + canBePlaced.Item1.x + " Y " + canBePlaced.Item1.y);
    }

    void Update()
    {
        
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
