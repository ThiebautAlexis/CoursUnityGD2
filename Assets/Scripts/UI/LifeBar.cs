using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI; 

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Image foregroundImage = null;
    [SerializeField] private Image middleGroundImage = null;
    [SerializeField] private float fillingSpeed = 2.0f;
    private float targetRatio, previousRatio;
    private float timer = 1f; 

    public void UpdateLifeRatio(int _currentHP, int _maxHP)
    {
        targetRatio = (float)_currentHP / _maxHP;
        previousRatio = middleGroundImage.fillAmount;
        timer = 0f;
        foregroundImage.fillAmount = targetRatio; 
    }

    private void Update()
    {
        if(timer < 1f)
        {
            timer += Time.deltaTime * fillingSpeed;
            middleGroundImage.fillAmount = (float)Mathf.Lerp(previousRatio,targetRatio, timer);
        }
    }
}
