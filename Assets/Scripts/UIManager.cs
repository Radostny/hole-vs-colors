using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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



    private void Start()
    {
        progressFillImage.fillAmount = 0f;
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
        progressFillImage.fillAmount = value;
    }
}
