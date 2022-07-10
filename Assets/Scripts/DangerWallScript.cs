using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DangerWallScript : MonoBehaviour
{
    // �I�u�W�F�N�g�ƐڐG�������ɌĂ΂��R�[���o�b�N
    void OnCollisionEnter(Collision hit)
    {
        // �ڐG�����I�u�W�F�N�g�̃^�O��"Player"�̏ꍇ
        if (hit.gameObject.CompareTag("Player"))
        {
            // ���݂̃V�[���ԍ����擾
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            // ���݂̃V�[�����ēǍ�����
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
