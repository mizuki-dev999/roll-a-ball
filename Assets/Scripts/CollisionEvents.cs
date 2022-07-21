using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionEvents
{
    /// <summary>
    /// "Player"との接書によるゲームリスタートメソッド
    /// </summary>
    /// <param name="hit">接触したオブジェクト</param>
    public static void CollisionPlayer(Collision hit)
    {
        // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag("Player"))
        {
            // 現在のシーン番号を取得
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            // 現在のシーンを再読込する
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
