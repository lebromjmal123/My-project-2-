using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roast : MonoBehaviour
{
    public Text displayText;       // Reference to a UI Text component
    public string[] textOptions;   // Array to store multiple text options

    void Start()
    {
        ShowRandomText();  // Show a random text when the game starts
    }

    public void ShowRandomText()
    {
        if (textOptions.Length == 0) return;  // Check if the list is empty

        int randomIndex = Random.Range(0, textOptions.Length);  // Pick a random index
        displayText.text = textOptions[randomIndex];  // Set the text
    }
}
