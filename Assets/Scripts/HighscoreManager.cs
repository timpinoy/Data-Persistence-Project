using UnityEngine;
using System.IO;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;
    public int Highscore { get; private set; }
    public string HighscoreName { get; private set; }
    public string CurrentName { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadHighscore();
    }

    public void UpdateHighscore(int highscore)
    {
        if (Highscore < highscore)
        {
            Highscore = highscore;
            HighscoreName = CurrentName;
            SaveHighscore();
        }
    }

    private void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.Highscore = Highscore;
        data.Name = HighscoreName;
        string path = Application.persistentDataPath + "/highscore.json";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    private void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        Debug.Log(path, this);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Highscore = data.Highscore;
            HighscoreName = data.Name;
        }
    }


    [System.Serializable]
    class SaveData
    {
        public int Highscore;
        public string Name;
    }
}
