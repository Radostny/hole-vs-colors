using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    
    
    [Header("Level Progress UI")]
    [SerializeField] int sceneOffset;

    [SerializeField] private TMP_Text nextLevelText;
    [SerializeField] private TMP_Text currentLevelText;
    [SerializeField] private Image progressFillImage;
    [Space]
    [SerializeField] private TMP_Text levelCompletedText;



    private void Start()
    {
        progressFillImage.fillAmount = 0f;
        SetLevelProgressText();
    }

    private void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();
    }

    public void UpdateLevelProgrees()
    {
        float value = 1f - ((float)Level.Instance.objectsInScene / Level.Instance.totalObjects);
        progressFillImage.DOFillAmount(value, .4f);
    }

    public void ShowLevelCompletedUI()
    {
        levelCompletedText.DOFade(1f, .6f).From(0f);
    }
}
