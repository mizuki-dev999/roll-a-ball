using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StageGenerator : MonoBehaviour
{
    [SerializeField, Label("プレイヤーオブジェクト")] GameObject playerObject;
    public GameObject mainCamera;
    [Header("ステージに生成するオブジェクト")]
    [SerializeField, Label("壁")] GameObject wall;
    [SerializeField, Label("障害物")] GameObject dangerWall;
    [SerializeField, Label("アイテム")] GameObject item;
    [SerializeField, Label("上下移動する障害物")] GameObject varticalMovementBlock;
    [SerializeField, Label("加速床(前)")] GameObject forwardAccelPoint;
    [SerializeField, Label("加速床(後)")] GameObject backForwardAccelPoint;
    [SerializeField, Label("加速床(左)")] GameObject leftAccelPoint;
    [SerializeField, Label("加速床(右)")] GameObject rightdAccelPoint;
    [Header("ステージ生成用")]
    [SerializeField, Label("生成したいステージの番号を入力")] int generateStageId = 0;
    [SerializeField, Label("ステージデータ")] StageData[] stageDatas = null;
    [Header("オブジェクト生成親")]
    public GameObject walls;
    public GameObject dangerWalls;
    public GameObject items;
    public GameObject varticalMovementBlocks;
    public GameObject accelPoints;

    void Start()
    {
        //プレイヤーオブジェクトとカメラの位置を初期化
        playerObject.transform.position = new Vector3(stageDatas[generateStageId].startPosision_x - 9.5f, 1, stageDatas[generateStageId].startPosision_y - 9.5f);
        mainCamera.transform.position = new Vector3(playerObject.transform.position.x, 9, playerObject.transform.position.z-5);
        //ステージを生成
        GenerateStage(stageDatas[generateStageId]);
    }

    /// <summary>
    /// ステージを生成するメソッド
    /// </summary>
    /// <param name="stageData">ステージデータ(ScriptalObject)</param>
    public void GenerateStage(StageData stageData)
    {

        int[][] objectPosisionDates = CsvReader(stageData.csvFile); // csvファイルを二次元配列に変換する
        for (int y = 0; y<objectPosisionDates.Length; y++)
        {
            for(int x = 0; x<objectPosisionDates[y].Length; x++)
            {   
                DeployObject(objectPosisionDates[y][x], x, y); // オブジェクトを設置する
            }
        }
    }

    /// <summary>
    /// CSVファイルを二次元配列に変換するメソッド
    /// </summary>
    /// <param name="textAsset">CSVファイル</param>
    /// <returns></returns>
    public int[][] CsvReader(TextAsset textAsset)
    {
        StringReader reader = new(textAsset.text);
        List<int[]> csvDatas = new(); //CSVの中身を格納
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            string[] strings = line.Split(',');
            int[] nums = new int[strings.Length];
            for(int i=0; i<strings.Length; i++) // int型に変換
            {
                if (strings[i] == "") nums[i] = 0;
                else nums[i] = int.Parse(strings[i]);
            }
            csvDatas.Add(nums);
        }
        return csvDatas.ToArray(); //二次元配列にして返す
    }

    /// <summary>
    /// 数字に対応したオブジェクトを配置するメソッド
    /// </summary>
    /// <param name="num">オブジェクト番号</param>
    /// <param name="x">x座標</param>
    /// <param name="y">y座標</param>
    public void DeployObject(int num, int x, int y)
    {
        switch (num)
        {
            case 0: //床
                break;
            case 1: //壁
                Instantiate(wall, new Vector3(x - 9.5f, 0.5f, 9.5f - y), Quaternion.identity, walls.transform);
                break;
            case 2: //障害物
                Instantiate(dangerWall, new Vector3(x - 9.5f, 0.5f, 9.5f - y), Quaternion.identity, dangerWalls.transform);
                break;
            case 3: //アイテム
                Instantiate(item, new Vector3(x - 9.5f, 0.5f, 9.5f - y), Quaternion.identity, items.transform);
                break;
            case 4: //上下移動する障害物
                Instantiate(varticalMovementBlock, new Vector3(x - 9.5f, 3, 9.5f - y), Quaternion.identity, varticalMovementBlocks.transform);
                break;
            case 5: //加速床(前)
                Instantiate(forwardAccelPoint, new Vector3(x - 9.5f, 0, 9.5f - y), Quaternion.identity, varticalMovementBlocks.transform);
                break;
            case 6: //加速床(後)
                Instantiate(backForwardAccelPoint, new Vector3(x - 9.5f, 0, 9.5f - y), Quaternion.identity, accelPoints.transform);
                break;
            case 7: //加速床(左)
                Instantiate(leftAccelPoint, new Vector3(x - 9.5f, 0, 9.5f - y), Quaternion.identity, accelPoints.transform);
                break;
            case 8: //加速床(右)
                Instantiate(rightdAccelPoint, new Vector3(x - 9.5f, 0, 9.5f - y), Quaternion.identity, accelPoints.transform);
                break;
            default: //床
                break;
        }
    }
}
