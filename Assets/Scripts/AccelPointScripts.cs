using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトを指定された方向にAddForceする
/// </summary>
public class AccelPointScripts : MonoBehaviour
{
    
    enum Direction //加速する方向
    {
        Forward, //前方
        Backward, //後方
        Right, //右
        Left //左
    };
    [SerializeField, Label("加速する方向")] private Direction direction;
    [SerializeField, Label("加速力")] private float accelerationPower;
    [SerializeField, Label("速度上限")] private float maxSpeed;
    private void OnTriggerStay(Collider other) => AccelPlayer(other);
    /// <summary>
    /// "Player"を加速するメソッド
    /// </summary>
    /// <param name="other"></param>
    private void AccelPlayer(Collider other)
    {
        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();
        if (other.gameObject.CompareTag("Player"))
        {
            //指定された方向の速度のみを対象のオブジェクトから取得する
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
            case Direction.Forward: //前方にAddForce
                vector = Vector3.forward;
                break;
            case Direction.Backward: //後方にAddForce
                vector = -Vector3.forward;
                break;
            case Direction.Right: //右方にAddForce
                vector = Vector3.right;
                break;
            case Direction.Left: //左方にAddForce
                vector = -Vector3.right;
                break;
            default:
                break;
        }
        return vector;
    }
}
