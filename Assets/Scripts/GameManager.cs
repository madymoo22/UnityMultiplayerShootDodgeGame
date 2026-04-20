using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event Action<int> onLivesChanged;
    public event Action onGameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayerHit(PlayerController player)
    {
        player.lives--;

        onLivesChanged?.Invoke(player.lives);

        if (player.lives <= 0)
        {
            onGameOver?.Invoke();

            DatabaseManager.Instance.SaveScore(player.lives);

            SceneManager.LoadScene("GameOverScene");
        }
    }
}