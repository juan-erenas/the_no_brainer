using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int _width;
    private int _height;
    private float _cellSize;
    private Vector3 _origin;

    private bool[][] _grid;

    public Grid(int width, int height, float cellSize, Vector3 origin)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _origin = origin;

        BuildGrid();
    }

    public void BuildGrid()
    {
        _grid = new bool[_width][];
        for (int i = 0; i < _width; i ++)
        {
            _grid[i] = new bool[_height];
        }
    }

    public (Vector3, bool) CanBePlaced(Vector3 arrowPosition, int widthInUnits, int heightInUnits)
    {
        Coordinate coord = ConvertToCoord(arrowPosition);

        List<Coordinate> coords = GetAllCoords(coord, widthInUnits, heightInUnits);

        bool canBePlaced = !CoordsAreTaken(coords);
        Vector3 centerPos = GetCenterPos(coords, _cellSize);

        return (centerPos, canBePlaced);
    }

    private Vector3 GetCenterPos(List<Coordinate> coords, float unitWidth)
    {
        int sumXPos = 0;
        int sumYPos = 0;

        for (int i = 0; i < coords.Count; i ++)
        {
            sumXPos += coords[i].X;
            sumYPos += coords[i].Y;
        }

        float halfUnitWidth = unitWidth / 2;

        float newXPos = (sumXPos / coords.Count) * unitWidth + _origin.x + _cellSize;
        float newYPos = (sumYPos / coords.Count) * unitWidth + _origin.y + _cellSize;

        if (coords.Count % 2 != 0)
        {
            newXPos -= halfUnitWidth;
            newYPos -= halfUnitWidth;
        }

        return new Vector3(newXPos, newYPos);
    }

    public void RemoveObjectFrom(Vector3 position, int widthInUnits, int heightInUnits)
    {
        float xPosInUnits = position.x - _origin.x / _cellSize;
        float yPosInUnits = position.y - _origin.y / _cellSize;

        int upperLeftXPos = (int)(xPosInUnits - (widthInUnits / 2));
        int upperLeftYPos = (int)(yPosInUnits - (heightInUnits / 2));

        List<Coordinate> coords = GetAllCoords(new Coordinate(upperLeftXPos, upperLeftYPos), widthInUnits, heightInUnits);

        for (int i = 0; i < coords.Count; i ++)
        {
            _grid[coords[i].X][coords[i].Y] = false;
            Debug.Log("Removed coord at X: " + coords[i].X + " Y: " + coords[i].Y);
        }
    }

    private List<Coordinate> GetAllCoords(Coordinate startingCoord, int width, int height)
    {
        List<Coordinate> coords = new List<Coordinate>();

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var newCoord = new Coordinate(startingCoord.X + i, startingCoord.Y + j);
                coords.Add(newCoord);
                Debug.Log("Will be placed on coord X: " + newCoord.X + " Y: " + newCoord.Y);
            }
        }

        return coords;
    }

    private bool CoordIsTaken(Coordinate coord)
    {
        if (!CoordIsValid(coord)) { return true; }

        return _grid[coord.X][coord.Y];
    }

    private bool CoordsAreTaken(List<Coordinate> coords)
    {
        for (int i = 0; i < coords.Count; i ++)
        {
            if (CoordIsTaken(coords[i]) == false) { return false; }
        }

        return true;
    }

    private bool CoordIsValid(Coordinate coord)
    {
        if (coord.X > _grid.Length - 1) { return false; }
        if (coord.Y > _grid[coord.X].Length - 1) { return false; }

        return true;
    }

    private Coordinate ConvertToCoord(Vector3 position)
    {
        int xVal = (int)((position.x - _origin.x) / _cellSize);
        int yVal = (int)((position.y - _origin.y) / _cellSize);

        return new Coordinate(xVal, yVal);
    }


}
