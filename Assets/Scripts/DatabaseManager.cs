using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance;

    private string dbPath;

    void Awake()
    {
        Instance = this;

        dbPath = "URI=file:" + Path.Combine(Application.persistentDataPath, "game.db");

        CreateTable();
    }

    void CreateTable()
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "CREATE TABLE IF NOT EXISTS Scores (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "score INTEGER);";

                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void SaveScore(int score)
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO Scores (score) VALUES (@score);";

                command.Parameters.Add(new SqliteParameter("@score", score));

                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        Debug.Log("Saved to DB");
    }

    public int GetHighScore()
    {
        int highScore = 0;

        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT MAX(score) FROM Scores;";

                var result = command.ExecuteScalar();

                if (result != null && result != System.DBNull.Value)
                {
                    highScore = int.Parse(result.ToString());
                }
            }

            connection.Close();
        }

        return highScore;
    }
}