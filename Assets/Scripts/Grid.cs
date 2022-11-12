using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int _width;
    private int _height;
    private float _unitWidth;
    private Vector3 _origin;

    private bool[][] _grid;

    public Grid(int width, int height, float unitWidth, Vector3 origin)
    {
        _width = width;
        _height = height;
        _unitWidth = unitWidth;
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

        bool canBePlaced = CoordsAreTaken(coords);
        Vector3 centerPos = GetCenterPos(coords, _unitWidth);

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

        float newXPos = (sumXPos / coords.Count) * unitWidth;
        float newYPos = (sumYPos / coords.Count) * unitWidth;

        return new Vector3(newXPos, newYPos);
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
        int xVal = (int)(position.x / _unitWidth);
        int yVal = (int)(position.y / _unitWidth);

        return new Coordinate(xVal, yVal);
    }


}
