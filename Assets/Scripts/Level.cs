using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static Level Instance;
    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

    [SerializeField] private Transform objectsParent;

    public int objectsInScene;
    public int totalObjects;

    private void Start()
    {
        CountObjects();
    }

    void CountObjects()
    {
        totalObjects = objectsParent.childCount;
        objectsInScene = totalObjects;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
