using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainInfo : MonoBehaviour
{
    public static MainInfo instance;

    public string playerName = "Player";

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

    }
    private void OnApplicationQuit()
    {
        throw new NotImplementedException();
    }
    
}
