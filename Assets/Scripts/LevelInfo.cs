using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class LevelInfo : MonoBehaviour
{
    [TextArea(20, 20)] public string ASCIILevel;
    /*
     {
        "level_1":
        {
        "1": ===x==========,
        "2": ======x=======,
        "4": =====x========,
        "5": ==========x===,
        "6": ===o====x=====,
        "7": =====x========,
        "8": ==x===========,
        }
        "level_2":
        {
        "1": =========x====,
        "2": ==x====x======,
        "4": ====x====o=x==,
        "5": =========x====,
        "6": ===x=======x==,
        "7": ========x=====,
        "8": ===x=======x==,
        }
        "level_3":
        {
        "1": =====x======x=,
        "2": ==x===x===x===,
        "4": ====x========x,
        "5": =x========x===,
        "6": ======x====x==,
        "7": ====x==x======,
        "8": =x======o==x==,
        }
        "level_4":
        {
        "1": ===x=====x==x=,
        "2": =x===x===x====,
        "4": ===x===x===x==,
        "5": ====o===x=====,
        "6": ==x==x======x=,
        "7": ====x===x==x==,
        "8": ===x====x====x,
        }
        "level_5"
        {
        "1": ===x==x===x==x,
        "2": ==x===x=x===x=,
        "4": x===x=x===x=x=,
        "5": ==x==x===x==x=,
        "6": ==x=x===x==o=x,
        "7": x=x===x===x=x=,
        "8": ==x=x====x==x=,
        }
        }
     */
    
    private int levelIndex = 0;

    private int fixedXPos = -16;
    private int fixedYPos = 30;
    private float fixedXGap = 2.5f;
    private float fixedYGap = 4.0f;
    

    private void Update()
    {
        //BuildLevel(levelIndex);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BuildLevel(1);
        }
    }

    void BuildLevel(int level)
    {
        JSONNode JsonLevelNode = JSON.Parse(ASCIILevel);
        string currentLevel = "level_" + level.ToString();
        JSONNode JsonLevel = JsonLevelNode[currentLevel];
        /*
         * I wanna fix this by replacing to variables later
         */
        for (int yLevelPos = 0; yLevelPos < 9; yLevelPos++)
        {
            string levelLine = JsonLevel[yLevelPos.ToString()].ToString();
            char[] characters = levelLine.ToCharArray();

            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {
                char c = characters[xLevelPos];

                if (c == 'x')
                {
                    GameObject newObstacle = Instantiate(Resources.Load<GameObject>("Prefabs/Hand"));
                    newObstacle.transform.position = new Vector3(xLevelPos*fixedXGap + fixedXPos, -yLevelPos*fixedYGap + fixedYPos, 0);
                }

                else if (c == 'o')
                {
                    GameObject newObstacle = Instantiate(Resources.Load<GameObject>("Prefabs/Can"));
                    newObstacle.transform.position = new Vector3(xLevelPos*fixedXGap + fixedXPos, -yLevelPos*fixedYGap + fixedYPos, 0);
                }
                
            }
            
        }
    }

}
