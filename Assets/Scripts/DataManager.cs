using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class DataManager : MonoBehaviour
{
    public class Data
    {
        public string name;
        public int score;

        public void SaveData()
        {
            string json = JsonUtility.ToJson(this);
            File.WriteAllText(Application.persistentDataPath + "/data.json", json);
        }

        public static Data LoadData()
        {
            Data data = null;
            if (File.Exists(Application.persistentDataPath + "/data.json"))
            {
                data = JsonUtility.FromJson<Data>(File.ReadAllText(Application.persistentDataPath + "/data.json"));
            }
            return data;

        }
    }

    public Data data;

    public static DataManager Instance;

    public string playerName = null;

    public void Awake()
    {


        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            data = Data.LoadData();

            if (data == null)
            {
                data = new Data();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void UpdateHighscore(int score)
    {
        if(score > data.score)
        {
            data.score = score;
            data.name = playerName;
        }
    }

    public string GetHighscore()
    {
        string text = null;
        if (data.score != 0)
        {
            text = "Best score: Name : " + data.name + " : " + data.score;
        }
        return text;
    }

    public void SaveData()
    {
        data.SaveData();
    }

}
