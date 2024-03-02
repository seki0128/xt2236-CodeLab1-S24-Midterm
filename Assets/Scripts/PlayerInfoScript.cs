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
    private void Awake()
    {
        playerInput = GameObject.Find("NameBar").GetComponent<TextMeshProUGUI>();
    }

    public void StartGame()
    {
        MainInfo.instance.playerName = playerInput.text;
        SceneManager.LoadScene(1);
    }
    
}
