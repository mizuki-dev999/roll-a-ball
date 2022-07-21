using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �I�u�W�F�N�g���w�肳�ꂽ������AddForce����
/// </summary>
public class AccelPointScripts : MonoBehaviour
{
    
    enum Direction //�����������
    {
        Forward, //�O��
        Backward, //���
        Right, //�E
        Left //��
    };
    [SerializeField, Label("�����������")] private Direction direction;
    [SerializeField, Label("������")] private float accelerationPower;
    [SerializeField, Label("���x���")] private float maxSpeed;
    private void OnTriggerStay(Collider other) => AccelPlayer(other);
    /// <summary>
    /// "Player"���������郁�\�b�h
    /// </summary>
    /// <param name="other"></param>
    private void AccelPlayer(Collider other)
    {
        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();
        if (other.gameObject.CompareTag("Player"))
        {
            //�w�肳�ꂽ�����̑��x�݂̂�Ώۂ̃I�u�W�F�N�g����擾����
            var objectSpeed = Vector3.Dot(targetRigidbody.velocity, GetDirection());
            if (objectSpeed < Mathf.Abs(maxSpeed))
            {
                targetRigidbody.AddForce(GetDirection() * accelerationPower, ForceMode.Acceleration);
            }
            targetRigidbody.AddForce(accelerationPower * GetDirection(), ForceMode.Acceleration);
        }
    }
    private Vector3 GetDirection()
    {
        Vector3 vector = new(0, 0, 0); 
        switch (direction)
        {
            case Direction.Forward: //�O����AddForce
                vector = Vector3.forward;
                break;
            case Direction.Backward: //�����AddForce
                vector = -Vector3.forward;
                break;
            case Direction.Right: //�E����AddForce
                vector = Vector3.right;
                break;
            case Direction.Left: //������AddForce
                vector = -Vector3.right;
                break;
            default:
                break;
        }
        return vector;
    }
}
