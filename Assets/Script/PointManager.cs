using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int pointCount;
    public Text pointText;

    void Update()
    {
        pointText.text = pointCount.ToString();
    }
}
