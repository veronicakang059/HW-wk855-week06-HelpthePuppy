using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public int currentLevel = 1;
    public bool isBalloonHere = true;
    public bool isGameOver = false;
    public Text textLevel;
    public int highestLevel;
    
    const string DIR_LOGS = "/Logs";
    const string FILE_HIGH_LEVELS = DIR_LOGS+"/highlevels.txt";
    string FILE_PATH_HIGH_LEVELS;


    public int CurrentLevel 
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            if (currentLevel > highestLevel)
            {
                HighestLevel = currentLevel;
            }
        }
    }
    

    public int HighestLevel
    {
        get
        {
            if (highestLevel < 1)
            {
                if (File.Exists(FILE_PATH_HIGH_LEVELS))
                {
                    string fileContents = File.ReadAllText(FILE_PATH_HIGH_LEVELS);
                    Debug.Log("file:"+fileContents);
                    highestLevel=Int32.Parse(fileContents);
                }
                else
                {
                    highestLevel = 1;
                }
            }
            return highestLevel;
        }
        set
        {
            highestLevel = value;
            Debug.Log("Wow,you entered a new level!");
            if (!File.Exists(FILE_PATH_HIGH_LEVELS))
            {
                Debug.Log("Create a new file");
                Directory.CreateDirectory(Application.dataPath + DIR_LOGS);
            }
            File.WriteAllText(FILE_PATH_HIGH_LEVELS,highestLevel+" ");
            
        }
    }

  

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        FILE_PATH_HIGH_LEVELS = Application.dataPath + FILE_HIGH_LEVELS;
        
        

    }

    // Update is called once per frame
    void Update()
    {

        if (!isBalloonHere)
        {
            CurrentLevel++;
            //highestLevel = Math.Max(highestLevel, currentLevel);
            SceneManager.LoadScene(currentLevel);
            isBalloonHere = true;
        }

        if (isGameOver)
        {
            Debug.Log("Game over! ");
            SceneManager.LoadScene("Scenes/Level-end");
            isGameOver = true;
            Destroy(gameObject);
        }

        textLevel.text = "Current level: " + CurrentLevel + 
                         "\n" + "Highest Level: " + HighestLevel;

    }

    
}
