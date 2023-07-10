using System;
using System.Collections;
using System.Collections.Generic;
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
            }
            if (tag.Equals("Object"))
            {
                Level.Instance.objectsInScene--;
                UIManager.Instance.UpdateLevelProgrees();
                
                Destroy(other.gameObject);
            }
        }
        
        
        
        
        

        
    }
}
