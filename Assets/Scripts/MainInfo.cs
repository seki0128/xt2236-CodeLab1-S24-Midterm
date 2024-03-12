using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using File = System.IO.File;
using SimpleJSON;

public class MainInfo : MonoBehaviour
{
    public static MainInfo instance;

    public bool isGameMode;
    public bool isSwitching = false;
    private bool isExecuteScoreList;
    
    public string playerName = "Player";
    public int playerScore = 0;

    private const string FILE_DIR = "/DATA/";
    private const string FILE_NAME = "data.json";
    private string FILE_FULL_PATH;

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

        FILE_FULL_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
    }

    private void Update()
    {
        if (isExecuteScoreList)
        {
            ReadScore();
        }
        
        if (!isGameMode && isSwitching)
        {
            isSwitching = false;
            RecordScore();
            WrapGame();
        }
    }
    
    public void StartGame()
    {
        isGameMode = true;
    }

    void WrapGame()
    {
        SceneManager.LoadScene(2);
        isExecuteScoreList = true;
    }

    void RecordScore()
    {
        JSONArray scoreArrayJSON = new JSONArray();
        
        if (File.Exists(FILE_FULL_PATH))
        {
            string JsonString = File.ReadAllText(FILE_FULL_PATH);
            JSONNode JsonScore = JSON.Parse(JsonString);
            scoreArrayJSON = JsonScore.AsArray;
        }
        else
        {
            // JSONObject: key + value
            JSONObject samplePlayer = new JSONObject();
            samplePlayer["name"] = "BananaCat";
            samplePlayer["score"] = 1;
            scoreArrayJSON.Add(samplePlayer);
        }

        JSONObject player = new JSONObject();
        player["name"] = playerName;
        player["score"] = playerScore;
        scoreArrayJSON.Add(player);
        
        string score = scoreArrayJSON.ToString();

        File.WriteAllText(FILE_FULL_PATH,score);
    }

    void ReadScore()
    {
        List<string> names = new List<string>();
        List<string> scores = new List<string>();
        if (File.Exists(FILE_FULL_PATH))
        {
            string JsonString = File.ReadAllText(FILE_FULL_PATH);
            JSONNode JsonScore = JSON.Parse(JsonString);
            JSONArray JsonScoreList = JsonScore.AsArray;

            foreach (JSONObject player in JsonScoreList)
            {
                string playerName = player["name"].Value;
                names.Add(playerName);
                string playerScore = player["score"].Value;
                scores.Add(playerScore);
            }
            
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            TextMeshPro scoreList = GameObject.Find("ScoreList").GetComponent<TextMeshPro>();
            string printScore = null;
            for (int i = 0; i < names.Count; i++)
            {
                printScore += names[i] + "          " + scores[i] + "\n";
            }

            scoreList.text = printScore;
            isExecuteScoreList = false;
        }


    }
    
    
}
