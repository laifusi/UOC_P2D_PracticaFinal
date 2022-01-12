using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyMachineOpenPoint : DropPoint
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    public override void ObjectDropped()
    {
        animator.SetTrigger("AddPart");
    }
}
