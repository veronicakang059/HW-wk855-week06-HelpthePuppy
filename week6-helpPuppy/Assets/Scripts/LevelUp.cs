using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > 7)
        {
            GameManager.instance.isGameOver = true;
        } 

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "dog")
        {
            Destroy(gameObject);
            GameManager.instance.isBalloonHere = false;
        }
    }
}
