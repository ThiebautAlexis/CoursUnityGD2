using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;


    private void Start()
    {
        PlayerController.UpdateScore += UpdateScoreUI; 
    }

    private void OnDestroy()
    {
        PlayerController.UpdateScore -= UpdateScoreUI;
    }

    public void UpdateScoreUI(int _score = 0)
    {
        scoreText.SetText($"Score : {_score.ToString("000 000")} points");
    }
}
