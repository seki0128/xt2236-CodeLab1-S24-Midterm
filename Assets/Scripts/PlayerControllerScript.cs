using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public int moveDistance = 2;

    private TextMeshPro playerNameText;

    void Awake()
    {
        playerNameText = GetComponentInChildren<TextMeshPro>();
        playerNameText.text = MainInfo.instance.playerName;
    }

    void Update()
    {
        Vector3 playerPos = transform.position;
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerPos = new Vector3(playerPos.x - moveDistance, playerPos.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerPos = new Vector3(playerPos.x + moveDistance, playerPos.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerPos = new Vector3(playerPos.x, playerPos.y + moveDistance, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerPos = new Vector3(playerPos.x, playerPos.y - moveDistance, 0);
        }

        transform.position = playerPos;
    }
}
