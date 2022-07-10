using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ScriptableObject/StageData")]
public class StageData : ScriptableObject
{
    public string stageName;
    public int id;
    [Range(0,19)]public int startPosision_x;
    [Range(0,19)] public int startPosision_y;
    public TextAsset csvFile;
}
