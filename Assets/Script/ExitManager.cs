using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public GameObject SelectIcon;
    public List<GameObject> MenuList;
    int MenuIndex = 0;
    public string MenuName = "Restart";
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectPreviousMenu();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectNextMenu();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (MenuName == "Restart")
            {
                SceneManager.LoadScene("Level");
            }
            if (MenuName == "Exit")
            {
                Application.Quit();
            }
        }
    }

    void SelectNextMenu()
    {
        MenuIndex = MenuIndex + 1;
        if (MenuIndex >= 2)
        {
            MenuIndex = 0;
        }
        GameObject SelectingMenu = MenuList[MenuIndex];
        SelectIcon.transform.position = new Vector2(SelectIcon.transform.position.x, SelectingMenu.transform.position.y);
        MenuName = SelectingMenu.name;
    }

    void SelectPreviousMenu()
    {
        MenuIndex = MenuIndex - 1;
        if (MenuIndex < 0)
        {
            MenuIndex = MenuList.Count - 1;
        }
        GameObject SelectingMenu = MenuList[MenuIndex];
        SelectIcon.transform.position = new Vector2(SelectIcon.transform.position.x, SelectingMenu.transform.position.y);
        MenuName = SelectingMenu.name;
    }
}
