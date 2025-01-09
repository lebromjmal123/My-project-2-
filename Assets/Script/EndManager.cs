using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject endUI;
    public void LoadGame()
    {
        SceneManager.LoadScene("Level");
        Debug.Log("load");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
