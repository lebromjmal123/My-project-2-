using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spaceText;

    void Start()
    {
        StartCoroutine(ShowSpaceText());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level");
        }
    }

    IEnumerator ShowSpaceText()
    {
        spaceText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
    }

}
