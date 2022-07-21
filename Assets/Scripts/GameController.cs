using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel;
    public GameObject winnerLabelObject;
    public void Update()
    {
        int count = GameObject.FindGameObjectsWithTag("Item").Length;
        scoreLabel.text = $"{count} items left";
        if(count == 0)
        {
            //ƒNƒŠƒA->winnerLabel‚ð•\Ž¦
            winnerLabelObject.SetActive(true);
        }
    }
}
