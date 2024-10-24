using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Axe,
        Rifle,
        Pistol,
        Shotgun,
        Potion
    }

    public ItemType itemType;
    public int amount;
}
