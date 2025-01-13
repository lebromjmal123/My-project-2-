using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winUI;
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
