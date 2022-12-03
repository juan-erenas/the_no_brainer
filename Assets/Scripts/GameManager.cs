using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlacementHandler _placementHandler;
    [SerializeField] private MachineFactory _machineFactory;

    private event EventHandler _mouseInteractedWithMachine;
    private event EventHandler _mouseMovedEvent;

    private bool _isDraggingMachine = false;

    // Start is called before the first frame update
    void Start()
    {
        var mousePos = GetMousePos();
        Debug.Log("Mouse pos is: x: " + mousePos.x + " y: " + mousePos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDraggingMachine)
        {
            var canBePlaced = _placementHandler.CanBePlaced(GetMousePos(), 1, 1);
        }
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint( Input.mousePosition );
    }


}
