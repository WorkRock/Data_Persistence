using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string inputPlayerName;
    public string maxPlayerName;
    public int maxScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string inputPlayerName;
        public string maxPlayerName;
        public int maxScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.inputPlayerName = inputPlayerName;
        data.maxPlayerName = maxPlayerName;
        data.maxScore = maxScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            inputPlayerName = data.inputPlayerName;
            maxPlayerName = data.maxPlayerName;
            maxScore = data.maxScore;
        }
    }

    public void ResetData()
    {
        inputPlayerName = "";
        maxPlayerName = "";
        maxScore = 0;
        SavePlayerData();
    }
}
