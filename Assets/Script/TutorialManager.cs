using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject menuUI;
    public void LoadGame()
    {
        SceneManager.LoadScene("Level");
        Debug.Log("load");
    }

   
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("quit");
    }


}
