using UnityEngine;

public class DangerWallScript : MonoBehaviour
{
    void OnCollisionEnter(Collision hit) => CollisionEvents.CollisionPlayer(hit);
}
