using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public int force = 50;
    private bool isEating;
    private bool isDefending;

    private TextMeshPro playerNameText;
    private SpriteRenderer sR;
    private PlayerInfoScript playerInfo;
    private Rigidbody2D rB;
    private AudioSource aS;

    void Awake()
    {
        aS = GetComponentInChildren<AudioSource>();
        rB = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        playerInfo = GetComponent<PlayerInfoScript>();
        playerNameText = GetComponentInChildren<TextMeshPro>();
        playerNameText.text = MainInfo.instance.playerName;
    }

    void Update()
    {
        MovePlayer();
        Eat();
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

    void Eat()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isEating = true;
            sR.sprite = Resources.Load<Sprite>("bananaCatKick");
        }
        else
        {
            isEating = false;
            sR.sprite = Resources.Load<Sprite>("bananaCat");
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            if (isEating)
            {
                Debug.Log("yummyyyyyy");
                Destroy(other.gameObject);
                aS.clip = Resources.Load<AudioClip>("Eat");
                aS.PlayOneShot(aS.clip);
                MainInfo.instance.playerScore ++;
            }
        }
        
        if (other.gameObject.CompareTag("Obstacle") )
        {
            /*
             *  I wanna add a VFX in this place
             */
            
            // When player collides with hands
            playerInfo.playerHeart--;
                GetHurt(); // Player turned red
                /*
                 *  The heart decreases one
                 */
            Debug.Log("bunch!!!!" + playerInfo.playerHeart);
        }


    }

    void GetHurt()
    {
        sR.color = Color.red;
        isDefending = true;
        
        
        TextMeshPro heartUI = GameObject.Find("Heart").GetComponent<TextMeshPro>();
        string currentCount = null;
        string heartCount = "\u2665";
        for (int i = 0; i < playerInfo.playerHeart; i++)
        {
            currentCount += heartCount;
        }

        heartUI.text = currentCount;
    }
    
    
}
