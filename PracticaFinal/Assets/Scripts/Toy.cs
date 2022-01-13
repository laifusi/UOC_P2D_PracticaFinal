using System;

public class Toy
{
    public ToyPart[] toyParts; //Parts of the toy

    /// <summary>
    /// Toy constructor
    /// </summary>
    /// <param name="parts">Toy parts</param>
    public Toy(ToyPart[] parts)
    {
        toyParts = parts;
    }
}

/// <summary>
/// Struct that defines a ToyPart
/// </summary>
[Serializable]
public struct ToyPart
{
    public TypeOfToy typeOfToy; //Type of toy
    public Part bodyPart; //Body part
}
