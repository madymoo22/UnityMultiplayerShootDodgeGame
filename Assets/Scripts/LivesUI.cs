using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onLivesChanged += UpdateLives;
        }
    }

    void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onLivesChanged -= UpdateLives;
        }
    }

    void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}