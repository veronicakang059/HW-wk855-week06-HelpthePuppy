using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MouseClicked : MonoBehaviour
{
    // Start is called before the first frame update
    public float floatSpeed = (float) 0.2;
    private bool mouseClicked = false;
    float yOriginPosition = (float) 5.0;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (mouseClicked)
        {
            Floating();
        }
    }

    private void OnMouseDown()
    {
        mouseClicked = true;
    }

    void Floating()
    {
        
        float yMovement = (float) floatSpeed * Time.deltaTime;
        yOriginPosition+=yMovement;
        transform.position = new Vector3(0, yOriginPosition, 0);
    }
}
