using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Item Lookup", menuName="Scriptable Objects/Item Lookup", order=0)]
public class ItemLookup : ScriptableObject
{
    public List<ItemDefinition> ItemDefinitions = new List<ItemDefinition>();

}

[System.Serializable]
public class ItemDefinition
{
    public ItemID ItemID;
    public Sprite ItemSprite;
    public string ItemName;
    public string ItemDescription;
}