using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int pointCount;
    public Text pointText;
    public static int pointScore;
    [SerializeField] Text highScoreText;

    
    void Start()
    {
        pointCount = pointScore;
        UpdateHighScoreText();
        pointCount = 0;
    }
    void Update()
    {
        pointScore = pointCount;
        pointText.text = pointCount.ToString();
        CheckHighScore();

        
        
    }
    void CheckHighScore()
    {
        if (pointCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", pointCount);
            PlayerPrefs.Save();
        }
    }
    void UpdateHighScoreText()
    {
        highScoreText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";
    }
    
}
