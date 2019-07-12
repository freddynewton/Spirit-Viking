using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;


public class SaveLoad : MonoBehaviour
{
    //private string filename = "GameData.json";
    //private string filePath;

    public Slider worldSizeSlider;
    public Dropdown dungeonTypeDropdown;

    public static int size;
    public static DungeonType dungeonType;

    private static SaveLoad _instance;
    public SaveLoad Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public GameData gameData;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(_instance == null)
        {
            _instance = new SaveLoad();
        }
        if (gameData == null)
        {
            gameData = new GameData();
        }
        /*
        filePath = Path.Combine(Application.dataPath, filePath);

        Debug.Log(filePath);
        */
    }


    // Start is called before the first frame update
    void Start()
    {
        //SaveGameData();
        //LoadGameData();
    }

    // Update is called once per frame
    void Update()
    {
    if(worldSizeSlider != null && dungeonTypeDropdown != null)
        {
            size = (int)worldSizeSlider.value;
            dungeonType = (DungeonType)dungeonTypeDropdown.value;
        } 

        //print("Size: " + size + ", dungeonType: " + dungeonType); 
    }
/*
    void LoadGameData()
    {
        string json;

        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
        } else
        {
            Debug.Log("File is missing: " + filePath);
        }
    }

    void SaveGameData()
    {
        string json = JsonUtility.ToJson(gameData);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        File.WriteAllText(filePath, json);
    }
*/
    [System.Serializable]
    public class GameData { 
        public int totalFloorCount;
        public DungeonType dungeonType;
    }
}
