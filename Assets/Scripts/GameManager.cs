using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlacementHandler PlacementHandler;

    public event EventHandler mouseInteractedWithMachine;
    public event EventHandler mouseMovedEvent;

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
            var canBePlaced = PlacementHandler.CanBePlaced(GetMousePos(), 1, 1);
        }
    }


    private Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint( Input.mousePosition );
    }

}
