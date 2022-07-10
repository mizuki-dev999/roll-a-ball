using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StageGenerator : MonoBehaviour
{
    [SerializeField, Label("�v���C���[�I�u�W�F�N�g")] GameObject playerObject;
    public GameObject mainCamera;
    [Header("�X�e�[�W�ɐ�������I�u�W�F�N�g")]
    [SerializeField, Label("��")] GameObject wall;
    [SerializeField, Label("��Q��")] GameObject dangerWall;
    [SerializeField, Label("�A�C�e��")] GameObject item;
    [Header("�X�e�[�W�����p")]
    [SerializeField, Label("�����������X�e�[�W�̔ԍ������")] int generateStageId = 0;
    [SerializeField, Label("�X�e�[�W�f�[�^")] StageData[] stageDatas = null;
    [Header("�I�u�W�F�N�g�����e")]
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
        int[][] objectPosisionDates = CsvReader(stageData.csvFile); // csv�t�@�C����񎟌��z��ɕϊ�����
        for (int y = 0; y<objectPosisionDates.Length; y++)
        {
            for(int x = 0; x<objectPosisionDates[y].Length; x++)
            {   
                DeployObject(objectPosisionDates[y][x], x, y); // �I�u�W�F�N�g��ݒu����
            }
        }
    }
    public int[][] CsvReader(TextAsset textAsset)
    {
        StringReader reader = new(textAsset.text);
        List<int[]> csvDatas = new(); //CSV�̒��g���i�[
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            string[] strings = line.Split(',');
            int[] nums = new int[strings.Length];
            for(int i=0; i<strings.Length; i++) // int�^�ɕϊ�
            {
                nums[i] = int.Parse(strings[i]); 
            }
            csvDatas.Add(nums);
        }
        return csvDatas.ToArray(); //�񎟌��z��ɂ��ĕԂ�
    }
    public void DeployObject(int num, int x, int y)
    {
        switch (num)
        {
            case 0: //��
                break;
            case 1: //��
                Instantiate(wall, new Vector3(x - 9.5f, 0.5f, 9.5f - y), Quaternion.identity, walls.transform);
                break;
            case 2: //��Q��
                Instantiate(dangerWall, new Vector3(x - 9.5f, 0.5f, 9.5f - y), Quaternion.identity, dangerWalls.transform);
                break;
            case 3: //�A�C�e��
                Instantiate(item, new Vector3(x - 9.5f, 0.5f, 9.5f - y), Quaternion.identity, items.transform);
                break;
            default:
                break;
        }
    }
}
