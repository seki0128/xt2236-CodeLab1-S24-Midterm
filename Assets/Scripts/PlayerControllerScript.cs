using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public int force = 50;
    private bool isKicking;

    private TextMeshPro playerNameText;
    private SpriteRenderer sR;
    private PlayerInfoScript playerInfo;
    private Rigidbody2D rB;

    void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
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
        if (Input.GetKey(KeyCode.A))
        {
            sR.flipX = false;
            rB.AddForce(Vector2.left * force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            sR.flipX = true;
            rB.AddForce(Vector2.right * force);
        }
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit");
        if (other.gameObject.CompareTag("Obstacle") )
        {
            /*
             *  I wanna add a VFX in this place
             */
            playerInfo.playerHeart--;
            Debug.Log("bunch!!!!" + playerInfo.playerHeart);
        }

        if (other.gameObject.CompareTag("Food"))
        {
            if (isKicking)
            {
                Destroy(other.gameObject);
                MainInfo.instance.playerScore++;
            }
        }
    }
    
}
