using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointShow : MonoBehaviour
{
    
    public Text pointText;
    public PointManager pointCount;
    // Update is called once per frame

    void Start()
    {
      pointCount  = FindAnyObjectByType<PointManager>();
    }
    void Update()
    {
        pointText.text = pointCount.ToString();
    }
}
