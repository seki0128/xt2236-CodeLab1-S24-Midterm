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
        "1": ===y=======x==,
        "2": ======y=======,
        "4": =x===y========,
        "5": ===y======y===,
        "6": ===y====y=====,
        "7": x====y=====x==,
        "8": ==x=y=========,
        }
        "level_2":
        {
        "1": y===y====x====,
        "2": ==x====x======,
        "4": ====x====y=x==,
        "5": ====y====x==y=,
        "6": =y=x=======x==,
        "7": ===y====x=====,
        "8": ===x===y===x==,
        }
        "level_3":
        {
        "1": =====x====y=x=,
        "2": ==x===xy==x===,
        "4": =y==x====y===x,
        "5": =x=====y==x===,
        "6": ===y==x====x==,
        "7": ====x==x===y==,
        "8": =x===y==y==x==,
        }
        "level_4":
        {
        "1": =y=x====yx==x=,
        "2": =x===x===x=y==,
        "4": ===x===x===x==,
        "5": ====y===x=y===,
        "6": ==x==x======x=,
        "7": ====x===x=yx==,
        "8": =y=x==y=x==y=x,
        }
        "level_5"
        {
        "1": =y=xy=x=y=x==x,
        "2": ==x===x=x===x=,
        "4": x=y=x=x===x=x=,
        "5": ==x==x===x==x=,
        "6": =yx=x===x==y=x,
        "7": x=x=y=x=y=x=x=,
        "8": ==xyx=y==x==x=,
        }
        }
     */
    
    private int levelIndex = 0;
    private int currentLevel = 0;

    private int fixedXPos = -14;
    private int fixedYPos = 45;
    private float fixedXGap = 1.5f;
    private float fixedYGap = 5.0f;
    
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

                if (c == 'y')
                {
                    GameObject newObstacle = Instantiate(Resources.Load<GameObject>("Prefabs/Can"));
                    newObstacle.transform.position = new Vector3(xLevelPos*fixedXGap + fixedXPos, -yLevelPos*fixedYGap + fixedYPos, 0);
                }
                
            }
            
        }
    }

    public void GoToNextLevel()
    {
        currentLevel++;

        if (currentLevel <= 5)
        {
            BuildLevel(currentLevel);
        }
        else
        {
            MainInfo.instance.isGameMode = false;
            MainInfo.instance.isSwitching = true;
        }

        
    }

}
