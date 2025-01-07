using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform mainCam;
    public Transform midBg;
    public Transform sideBg;
    public float length;

    void Update()
    {
        if (mainCam.position.x > midBg.position.x)
        {
            UpdateBackGroundPosition(Vector3.right);
        }

        else if (mainCam.position.x < midBg.position.x)
        {
            UpdateBackGroundPosition(Vector3.left);
        }
    }

    void UpdateBackGroundPosition(Vector3 direction)
    {
        sideBg.position = midBg.position + direction * length;  
        Transform temp = midBg;
        midBg = sideBg;
        sideBg = temp;
    }
}
