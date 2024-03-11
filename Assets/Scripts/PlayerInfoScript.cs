using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfoScript : MonoBehaviour
{
    private TextMeshProUGUI playerInput;
    private TextMeshPro score;
    
    public int playerHeart = 3;
    
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            playerInput = GameObject.Find("NameBar").GetComponent<TextMeshProUGUI>();
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            score = GameObject.Find("Score").GetComponent<TextMeshPro>();
        }
    }

    private void Update()
    {
        if (playerHeart <= 0)
        {
            MainInfo.instance.isGameMode = false;
            MainInfo.instance.isSwitching = true;
            Debug.Log("game is over");
            playerHeart = 3;
        }

        score.text = "U ATE \n" + MainInfo.instance.playerScore + "\nCAN(s)";
    }

    public void StartGame()
    {
        MainInfo.instance.playerName = playerInput.text;
        SceneManager.LoadScene(1);
    }
    
}
