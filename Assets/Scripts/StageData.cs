using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ScriptableObject/StageData")]
public class StageData : ScriptableObject
{
    [SerializeField, Label("�X�e�[�W��")] public string stageName;
    [SerializeField, Label("�X�e�[�W�ԍ�")] public int id;
    [SerializeField, Label("�v���C���[����X���W")] [Range(0,19)]public int startPosision_x;
    [SerializeField, Label("�v���C���[����Y���W")] [Range(0,19)] public int startPosision_y;
    [SerializeField, Label("CSV�t�@�C�����Z�b�g���Ă�������")] public TextAsset csvFile;
}
