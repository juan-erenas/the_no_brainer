using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public decimal Price => _machineModel.Price;
    public int Width => _machineModel.Width;
    public int Height => _machineModel.Height;
    public MachineType Type => _machineModel.Type;

    private MachineModel _machineModel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMachineModel(MachineModel model)
    {
        _machineModel = model;
    }
}
