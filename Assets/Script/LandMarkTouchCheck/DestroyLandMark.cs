using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLandMark : MonoBehaviour
{

    public bool touched1 = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touched1 == true)
        {
            
               
            Destroy(gameObject, 5);
              
        }
    }
}
