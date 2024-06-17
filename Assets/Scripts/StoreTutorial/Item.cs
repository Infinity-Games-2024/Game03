/*
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{

    [Header("Only gameplay")]
    public TileBase tile;
    public ToolboxItemFilterType toolboxItemFilterType;
    public ItemType type; //generated ItemType in new file
    public InputActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);
    [Header("Only UI")]
    public bool stackable = false;
    [Header("Both")]
    public Sprite image;

}

public enum ItemType
{
    BuildingBlock,
    Tool
}

public enum ActionType
{
    Dig,
    Mine
}
*/