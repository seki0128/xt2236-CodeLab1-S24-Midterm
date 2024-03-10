using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float moveSpeed;
    private float minYPos = -6;
    private float timer = 0.2f;
    private float time = 0;
    
    void Update()
    {
        // Move the obstacle every timer gap
        if (time <= timer)
        {
            time += Time.deltaTime;
        }
        else
        {
            Move();
            time = 0;
        }
        // When the obstacle move out of the screen, destroy it
        if (transform.position.y <= minYPos)
        {
            Destroy(gameObject);
        }

    }

    void Move()
    {
        float posY = transform.position.y;
        posY -= moveSpeed;
        
        transform.position = new Vector3(
            transform.position.x,
            posY,
            transform.position.z);
    }
}
