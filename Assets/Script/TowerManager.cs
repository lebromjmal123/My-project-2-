using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance;

    public int score = 0;
    public Text scoreText;  // Link this to a UI Text in the Inspector

    private void Awake()
    {
        // Correct Singleton pattern setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Optional: Persist between scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject);  // Destroys duplicate TowerManager GameObjects
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score Updated: " + score);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
