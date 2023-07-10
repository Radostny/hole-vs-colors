using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UndergroundCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag.Equals("Obstacle"))
        {
            //restart level
            Debug.Log("Obstacle");
        }
        if (tag.Equals("Object")) 
        {
            Debug.Log("Object");
        }
        
    }
}
