using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ScriptableObject/StageData")]
public class StageData : ScriptableObject
{
    [SerializeField, Label("ステージ名")] public string stageName;
    [SerializeField, Label("ステージ番号")] public int id;
    [SerializeField, Label("プレイヤー初期X座標")] [Range(0,19)]public int startPosision_x;
    [SerializeField, Label("プレイヤー初期Y座標")] [Range(0,19)] public int startPosision_y;
    [SerializeField, Label("CSVファイルをセットしてください")] public TextAsset csvFile;
}
