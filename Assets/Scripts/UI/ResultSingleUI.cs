using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI playerScoreText;

    public void SetResults(string playerName, int playerScore)
    {
        playerNameText.text = playerName;
        playerScoreText.text = playerScore.ToString();
    }
}
