using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance { get; private set; }

    private string savePath;
    private GameData data;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        savePath = Path.Combine(Application.persistentDataPath, "save.json");

        LoadGame();
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Game saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            data = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Game loaded!");
        }
        else
        {
            data = new GameData();
            data.highScore = 0;
            data.gamesPlayed = 0;

            Debug.Log("New save created");
        }
    }

    public void UpdateScore(int score)
    {
        if (score > data.highScore)
        {
            data.highScore = score;
        }

        data.gamesPlayed++;
        SaveGame();
    }

    public int GetHighScore()
    {
        return data.highScore;
    }
}