using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    private GridDisplay _grid;
    private int _gridWidth = 20;
    private int _gridHeight = 10;
    private float _unitWidth = 1f;

    [SerializeField] Material LineMaterial;

    void Start()
    {
        _grid = BuildGrid(_gridWidth, _gridHeight, _unitWidth, this.transform.position, LineMaterial);
    }

    void Update()
    {
        
    }

    public GridDisplay BuildGrid(int width, int height, float unitWidth, Vector3 origin, Material material)
    {
        GameObject emptyObject = new GameObject();
        emptyObject.transform.parent = this.transform;
        emptyObject.name = "GridLines";

        GridDisplay newGrid = new GridDisplay(width, height, unitWidth, origin, material);
        List<GameObject> gridLines = newGrid.AddGridLines();

        for (int i = 0; i < gridLines.Count; i ++)
        {
            gridLines[i].transform.parent = emptyObject.transform;
        }

        return newGrid;
    }
}
