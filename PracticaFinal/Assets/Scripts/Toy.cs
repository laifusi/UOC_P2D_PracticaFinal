using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy
{
    public ToyPart[] toyParts;

    public Toy(ToyPart[] parts)
    {
        toyParts = parts;
    }
}

[Serializable]
public struct ToyPart
{
    public TypeOfToy typeOfToy;
    public Part bodyPart;
}
