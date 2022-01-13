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

    public override void ItemDropped(ItemSO item)
    {
        toyMachine.AddToyPart(item);
    }

    public override void ToyDropped(ToyObject toy)
    {
        toy.ReturnToLastPoint();
    }
}
