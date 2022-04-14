using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Master Item Table
/// </summary>
[CreateAssetMenu(fileName = "WeaponTable", menuName = "Items/ItemTable", order = 3)]
public class ItemTable : ScriptableObject
{
    public List<ItemScript> itemTable;

    public ItemScript getItemIndex(int index)
    {
        ItemScript itemToGet = itemTable[index];
        return itemToGet;
    }
}