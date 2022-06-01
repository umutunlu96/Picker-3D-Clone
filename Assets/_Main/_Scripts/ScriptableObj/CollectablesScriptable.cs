using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectable")]

public class CollectablesScriptable : ScriptableObject
{
    public string collectableName;
    public float collectableMass;
    public Vector3 collectableScale = Vector3.one;
    public Material[] collectableMaterial;
}