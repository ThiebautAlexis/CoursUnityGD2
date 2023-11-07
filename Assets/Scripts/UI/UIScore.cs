using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;


    private void Start()
    {
        PlayerController.UpdateScore += UpdateScore; 
    }

    private void OnDestroy()
    {
        PlayerController.UpdateScore -= UpdateScore;
    }

    public void UpdateScore(int _score = 0)
    {
        scoreText.text = _score.ToString("000 000");
    }
}
