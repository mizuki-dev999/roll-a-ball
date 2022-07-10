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
    [Header("ステージ生成用")]
    [SerializeField, Label("生成したいステージの番号を入力")] int generateStageId = 0;
    [SerializeField, Label("ステージデータ")] StageData[] stageDatas = null;
    [Header("オブジェクト生成親")]
    public GameObject walls;
    public GameObject dangerWalls;
    public GameObject items;

    void Start()
    {
        playerObject.transform.position = new Vector3(stageDatas[generateStageId].startPosision_x - 9.5f, 1, stageDatas[generateStageId].startPosision_y - 9.5f);
        mainCamera.transform.position = new Vector3(playerObject.transform.position.x, 9, playerObject.transform.position.z-5);
        GenerateStage(stageDatas[generateStageId]);
    }
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
                nums[i] = int.Parse(strings[i]); 
            }
            csvDatas.Add(nums);
        }
        return csvDatas.ToArray(); //二次元配列にして返す
    }
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
            default:
                break;
        }
    }
}
