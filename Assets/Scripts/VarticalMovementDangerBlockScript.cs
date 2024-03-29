using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarticalMovementDangerBlockScript : MonoBehaviour
{
    [SerializeField, Label("上下移動の速さ")] private float Speed;
    void OnCollisionEnter(Collision hit) => CollisionEvents.CollisionPlayer(hit);

    private void Update() => VarticalMove();

    /// <summary>
    /// 上下移動メソッド
    /// </summary>
    private void VarticalMove()
    {
        var y = Mathf.PingPong(Time.time*Speed, 3);
        transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Clamp(3-y, 0.5f, 3), this.transform.localPosition.z);
    }
}
