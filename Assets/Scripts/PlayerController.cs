using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10; //�v���C���[�̑��x
    private void FixedUpdate()
    {
        // ���͂�x��z�ɑ��
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // �����GameObject������Rigidbody�R���|�[�l���g���擾
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        // rigidbody��x���i���j��z���i���j�ɗ͂�������
        rigidbody.AddForce(x * speed, 0, z * speed);
    }
}
