using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public Sprite sprite; //Sprite of the item
    public Part bodyPart; //body part
    public TypeOfToy typeOfToy; //type of toy
}

/// <summary>
/// Enum that defines the four parts of a toy
/// </summary>
public enum Part
{
    Head, Body, Leg, Arm
}

/// <summary>
/// Enum that defines the four types of toy
/// </summary>
public enum TypeOfToy
{
    Doll, Robot, Bunny, Teddy
}
