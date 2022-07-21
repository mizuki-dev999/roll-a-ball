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
    [SerializeField, Label("�㉺�ړ������Q��")] GameObject varticalMovementBlock;
    [SerializeField, Label("������(�O)")] GameObject forwardAccelPoint;
    [SerializeField, Label("������(��)")] GameObject backForwardAccelPoint;
    [SerializeField, Label("������(��)")] GameObject leftAccelPoint;
    [SerializeField, Label("������(�E)")] GameObject rightdAccelPoint;
    [Header("�X�e�[�W�����p")]
    [SerializeField, Label("�����������X�e�[�W�̔ԍ������")] int generateStageId = 0;
    [SerializeField, Label("�X�e�[�W�f�[�^")] StageData[] stageDatas = null;
    [Header("�I�u�W�F�N�g�����e")]
    public GameObject walls;
    public GameObject dangerWalls;
    public GameObject items;
    public GameObject varticalMovementBlocks;
    public GameObject accelPoints;

    void Start()
    {
        //�v���C���[�I�u�W�F�N�g�ƃJ�����̈ʒu��������
        playerObject.transform.position = new Vector3(stageDatas[generateStageId].startPosision_x - 9.5f, 1, stageDatas[generateStageId].startPosision_y - 9.5f);
        mainCamera.transform.position = new Vector3(playerObject.transform.position.x, 9, playerObject.transform.position.z-5);
        //�X�e�[�W�𐶐�
        GenerateStage(stageDatas[generateStageId]);
    }

    /// <summary>
    /// �X�e�[�W�𐶐����郁�\�b�h
    /// </summary>
    /// <param name="stageData">�X�e�[�W�f�[�^(ScriptalObject)</param>
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

    /// <summary>
    /// CSV�t�@�C����񎟌��z��ɕϊ����郁�\�b�h
    /// </summary>
    /// <param name="textAsset">CSV�t�@�C��</param>
    /// <returns></returns>
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
                if (strings[i] == "") nums[i] = 0;
                else nums[i] = int.Parse(strings[i]);
            }
            csvDatas.Add(nums);
        }
        return csvDatas.ToArray(); //�񎟌��z��ɂ��ĕԂ�
    }

    /// <summary>
    /// �����ɑΉ������I�u�W�F�N�g��z�u���郁�\�b�h
    /// </summary>
    /// <param name="num">�I�u�W�F�N�g�ԍ�</param>
    /// <param name="x">x���W</param>
    /// <param name="y">y���W</param>
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
            case 4: //�㉺�ړ������Q��
                Instantiate(varticalMovementBlock, new Vector3(x - 9.5f, 3, 9.5f - y), Quaternion.identity, varticalMovementBlocks.transform);
                break;
            case 5: //������(�O)
                Instantiate(forwardAccelPoint, new Vector3(x - 9.5f, 0, 9.5f - y), Quaternion.identity, varticalMovementBlocks.transform);
                break;
            case 6: //������(��)
                Instantiate(backForwardAccelPoint, new Vector3(x - 9.5f, 0, 9.5f - y), Quaternion.identity, accelPoints.transform);
                break;
            case 7: //������(��)
                Instantiate(leftAccelPoint, new Vector3(x - 9.5f, 0, 9.5f - y), Quaternion.identity, accelPoints.transform);
                break;
            case 8: //������(�E)
                Instantiate(rightdAccelPoint, new Vector3(x - 9.5f, 0, 9.5f - y), Quaternion.identity, accelPoints.transform);
                break;
            default: //��
                break;
        }
    }
}
