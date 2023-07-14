using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UndergroundCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!Game.isGameover)
        {
            string tag = other.tag;
            if (tag.Equals("Obstacle"))
            {
                Game.isGameover = true;
                Camera.main.transform
                    .DOShakePosition(1f, .2f, 20, 90f)
                    .OnComplete(() =>
                    {
                        Level.Instance.RestartLevel();
                    });

            }
            if (tag.Equals("Object"))
            {
                Level.Instance.objectsInScene--;
                UIManager.Instance.UpdateLevelProgrees();
                
                Destroy(other.gameObject);

                if (Level.Instance.objectsInScene == 0)
                {
                    UIManager.Instance.ShowLevelCompletedUI();
                    Invoke("NextLevel", 2f);
                }
            }
        }

        void NextLevel()
        {
            Level.Instance.LoadNextLevel();
        }
        
        
        
        
        

        
    }
}
