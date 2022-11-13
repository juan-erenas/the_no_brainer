using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDisplay
{
    private int _width;
    private int _height;
    private float _cellSize;
    private List<GameObject> _gridLineRenderers;
    private Vector3 _origin;
    private Material _material;

    private Color _startColor = new Color(0.1f, 0.1f, 0.1f);
    private Color _endColor = new Color(0.1f, 0.1f, 0.1f);

    public GridDisplay(int width, int height, float cellSize, Vector3 origin, Material material)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _origin = origin;
        _material = material;
    }

    public List<GameObject> AddGridLines()
    {
        _gridLineRenderers = GenerateLines(_width, _height, _cellSize, _origin);

        return _gridLineRenderers;
    }

    private List<GameObject> GenerateLines(int width, int height, float unitWidth, Vector3 origin)
    {
        List<GameObject> lineRenderers = new List<GameObject>();

        float topYPos = origin.y + (height * unitWidth);
        float rightXPos = origin.x + (width * unitWidth);
        float lineWidth = unitWidth / 70;

        for (int i = 0; i < _width + 1; i++)
        {
            float lineXPos = origin.x + (i * unitWidth);
            Vector3 startPos = new Vector3(lineXPos, origin.y);
            Vector3 endPos = new Vector3(lineXPos, topYPos);

            GameObject line = BuildLine(new Vector3[] { startPos, endPos }, lineWidth);
            lineRenderers.Add(line);
        }

        for (int i = 0; i < _height + 1; i++)
        {
            float lineYPos = origin.y + (i * unitWidth);
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

        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(_startColor, 0.0f), new GradientColorKey(_endColor, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );

        lineRenderer.colorGradient = gradient;

        lineRenderer.material = _material;

        lineRenderer.useWorldSpace = false;

        return newObject;
    }

    

}
