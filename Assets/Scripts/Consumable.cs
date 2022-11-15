using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable", menuName = "Items/Consumable")]

public class Consumable : Items
{
    public ConsumableType type;
}

public enum ConsumableType { Food, Ammo }
