using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        int highScore = DatabaseManager.Instance.GetHighScore();

        highScoreText.text = "High Score: " + highScore;
    }
}