using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public Sprite sprite;
    public Part bodyPart;
}

public enum Part
{
    Head, Body, Leg, Arm
}
