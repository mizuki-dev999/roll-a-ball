using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // �g���K�[�Ƃ̐ڐG���ɌĂ΂��R�[���o�b�N
    void OnTriggerEnter(Collider hit)
    {
        // �ڐG�Ώۂ�Player�^�O�ł����H
        if (hit.CompareTag("Player"))
        {
            // ���̃R���|�[�l���g������GameObject��j������
            Destroy(gameObject);
        }
    }
}
