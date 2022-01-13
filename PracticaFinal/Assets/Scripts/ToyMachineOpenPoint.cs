using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyMachineOpenPoint : DropPoint
{
    private ToyMachine toyMachine;
    private AudioSource audioSource;

    private void Start()
    {
        toyMachine = GetComponentInParent<ToyMachine>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void ItemDropped(ItemSO item)
    {
        audioSource.Play();
        toyMachine.AddToyPart(item);
    }

    public override void ToyDropped(ToyObject toy)
    {
        toy.ReturnToLastPoint();
    }
}
