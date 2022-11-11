using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    private Grid _grid;
    private int _gridWidth = 20;
    private int _gridHeight = 10;
    private float _unitWidth = 1f;

    void Start()
    {
        _grid = BuildGrid(_gridWidth, _gridHeight, _unitWidth, this.transform.position);
    }

    void Update()
    {
        
    }

    public Grid BuildGrid(int width, int height, float unitWidth, Vector3 origin)
    {
        GameObject emptyObject = new GameObject();
        emptyObject.transform.parent = this.transform;
        emptyObject.name = "GridLines";

        Grid newGrid = new Grid(width, height, unitWidth, origin);
        List<GameObject> gridLines = newGrid.AddGridLines();

        for (int i = 0; i < gridLines.Count; i ++)
        {
            gridLines[i].transform.parent = emptyObject.transform;
        }

        return newGrid;
    }
}
