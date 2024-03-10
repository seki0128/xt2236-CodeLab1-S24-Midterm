using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfoScript : MonoBehaviour
{
    private TextMeshProUGUI playerInput;
    
    public int playerHeart = 3;
    
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            playerInput = GameObject.Find("NameBar").GetComponent<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        if (playerHeart <= 0)
        {
            MainInfo.instance.isGameMode = false;
            Debug.Log("game is over");
            
        }
    }

    public void StartGame()
    {
        MainInfo.instance.playerName = playerInput.text;
        SceneManager.LoadScene(1);
    }
    
}
