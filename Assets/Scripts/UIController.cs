using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UIController : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Update()
    {

        if (GameManager.Instance.score == 0) { 
            scoreText.text = string.Empty;
        }
        else
        {
            scoreText.text = "COINS: " + GameManager.Instance.score;
        }
    }

}
