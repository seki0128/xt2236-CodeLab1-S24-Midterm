using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfoScript : MonoBehaviour
{
    private TextMeshProUGUI playerInput;
    
    public string playerName;
    public int playerHeart = 3;
    
    private void Awake()
    {
        if (SceneManager.sceneCount == 0)
        {
            playerInput = GameObject.Find("NameBar").GetComponent<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        if (playerHeart <= 0)
        {
            MainInfo.instance.isGameMode = false;
        }
    }

    public void StartGame()
    {
        MainInfo.instance.playerName = playerInput.text;
        SceneManager.LoadScene(1);
    }
    
}
