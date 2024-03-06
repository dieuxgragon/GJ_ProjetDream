using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "NewItem")]
public class ScriptableObjects : ScriptableObject
{
    public GameObject prefab;
    public string name;
    public string description;
    public ObjectType objectType;

}

public enum ObjectType 
{
    defaultType,
    interactible,
    talkable,
    sceneChangeEast,
    sceneChangeNorth,
    sceneChangeSouth,
    sceneChangeWest


}
