using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MachineFactory : MonoBehaviour
{
    [SerializeField] private List<MachineScriptable> _machineScritableObjects;
    private List<MachineModel> _machineModels;

    // Start is called before the first frame update
    void Start()
    {
        _machineModels = BuildMachineModels(_machineScritableObjects);
    }

    public Machine GetMachineOfType(MachineType machineType)
    {
        Machine newMachine = new Machine();
        newMachine.SetMachineModel( GetModelOfType(machineType) );
        return newMachine;
    }

    private MachineModel GetModelOfType(MachineType type)
    {
        for (int i = 0; i < _machineModels.Count; i++)
        {
            if (_machineModels[i].Type == type)
            {
                return _machineModels[i];
            }
        }

        throw new Exception("No machine model was instantiated of type: " + type.ToString());
    }

    private List<MachineModel> BuildMachineModels(List<MachineScriptable> machineSO)
    {
        List<MachineModel> models = new List<MachineModel>();

        for (int i = 0; i < machineSO.Count; i++)
        {
            MachineScriptable machine = machineSO[i];

            MachineModel newModel = new MachineModel();
            newModel.Price = machine.Price;
            newModel.Width = machine.Width;
            newModel.Height = machine.Height;
            newModel.Type = GetMachineType(machine.TypeString);

            models.Add(newModel);
        }

        return models;
    }

    private MachineType GetMachineType(string machineTypeString)
    {
        MachineType type;
        bool parsedSuccessfully;

        parsedSuccessfully = Enum.TryParse(machineTypeString, out type);

        if (parsedSuccessfully == false)
        {
            throw new Exception("Machine type on scritable object does not match any enum machineType values: " + machineTypeString);
        }

        return type;
    }



}
