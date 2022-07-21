using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionEvents
{
    /// <summary>
    /// "Player"�Ƃ̐ڏ��ɂ��Q�[�����X�^�[�g���\�b�h
    /// </summary>
    /// <param name="hit">�ڐG�����I�u�W�F�N�g</param>
    public static void CollisionPlayer(Collision hit)
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
