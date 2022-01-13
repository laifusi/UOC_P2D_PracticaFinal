using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyMachineOpenPoint : DropPoint
{
    private ToyMachine toyMachine;

    private void Start()
    {
        toyMachine = GetComponentInParent<ToyMachine>();
    }

    public override void ObjectDropped(ItemSO item)
    {
        toyMachine.AddToyPart(item);
    }
}
