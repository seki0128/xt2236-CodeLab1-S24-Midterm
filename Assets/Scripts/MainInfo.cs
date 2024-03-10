using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainInfo : MonoBehaviour
{
    public static MainInfo instance;

    public bool isGameMode;
    public string playerName = "Player";
    public int distanceSpeed;
    public int distanceRecord = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        StartGame();
    }

    private void Update()
    {
        if (isGameMode)
        {
            distanceRecord += distanceSpeed;
        }
    }

    private void OnApplicationQuit()
    {
        throw new NotImplementedException();
    }

    public void StartGame()
    {
        isGameMode = true;
    }
}
