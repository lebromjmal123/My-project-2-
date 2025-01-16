using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance;

    public int score = 0;
    public Text scoreText;  // Link this to a UI Text in the Inspector


    void Start()
    {
        score = 0;
    }
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

    void Update()
    {
        if (score == 10)
        {
            SceneManager.LoadScene("Win");
            score = 0;
        }

        if (scoreText == null)
        {

            GameObject textObject = GameObject.Find("CurrentTower");  // Replace with your Text object's name
            if (textObject != null)
            {
                scoreText = textObject.GetComponent<Text>();
            }
            else
            {
                Debug.LogWarning("ScoreText UI not found in the scene.");
            }

        }
        

    }

    public void ResetScore()
    {
        score = 0;
    }
}
