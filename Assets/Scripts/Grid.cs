using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int _width;
    private int _height;
    private float _unitWidth;
    private List<GameObject> _gridLineRenderers;
    private Vector3 _origin;

    public Grid(int width, int height, float unitWidth, Vector3 origin)
    {
        _width = width;
        _height = height;
        _unitWidth = unitWidth;
        _origin = origin;

    }

    public List<GameObject> AddGridLines()
    {
        _gridLineRenderers = GenerateLines(_width, _height, _unitWidth, _origin);

        return _gridLineRenderers;
    }

    private List<GameObject> GenerateLines(int width, int height, float unitWidth, Vector3 origin)
    {
        List<GameObject> lineRenderers = new List<GameObject>();

        float bottomYPos = origin.y - (height * unitWidth);
        float rightXPos = origin.x + (width * unitWidth);
        float lineWidth = unitWidth / 70;

        for (int i = 0; i < _width + 1; i++)
        {
            float lineXPos = origin.x + (i * unitWidth);
            Vector3 startPos = new Vector3(lineXPos, origin.y);
            Vector3 endPos = new Vector3(lineXPos, bottomYPos);

            GameObject line = BuildLine(new Vector3[] { startPos, endPos }, lineWidth);
            lineRenderers.Add(line);
        }

        for (int i = 0; i < _height + 1; i++)
        {
            float lineYPos = origin.y - (i * unitWidth);
            Vector3 startPos = new Vector3(origin.x, lineYPos);
            Vector3 endPos = new Vector3(rightXPos, lineYPos);

            GameObject line = BuildLine(new Vector3[] { startPos, endPos }, lineWidth);
            lineRenderers.Add(line);
        }

        return lineRenderers;
    }

    private GameObject BuildLine(Vector3[] positions, float lineWidth)
    {
        GameObject newObject = new GameObject();
        LineRenderer lineRenderer = newObject.AddComponent<LineRenderer>();

        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.SetPositions(positions);

        lineRenderer.useWorldSpace = false;

        return newObject;
    }

    

}
