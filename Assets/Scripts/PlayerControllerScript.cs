using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public int moveDistance = 2;
    private bool isKicking;

    private TextMeshPro playerNameText;
    private SpriteRenderer sR;
    private PlayerInfoScript playerInfo;

    void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
        playerInfo = GetComponent<PlayerInfoScript>();
        playerNameText = GetComponentInChildren<TextMeshPro>();
        playerNameText.text = MainInfo.instance.playerName;
    }

    void Update()
    {
        MovePlayer();
        KickObstacle();
    }

    void MovePlayer()
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

    void KickObstacle()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isKicking = true;
            sR.sprite = Resources.Load<Sprite>("bananaCatKick");
        }
        else
        {
            isKicking = false;
            sR.sprite = Resources.Load<Sprite>("bananaCat");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle" )
        {
            if (isKicking)
            {
                Destroy(other.gameObject);
            }
            else
            {
                /*
                 *  I wanna add a VFX in this place
                 */
                playerInfo.playerHeart--;
                Debug.Log("bunch!!!!" + playerInfo.playerHeart);
            }
        }
    }
}
