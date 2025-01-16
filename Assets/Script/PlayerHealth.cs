using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float healthAmount;
    private Animator anim;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            TowerManager.Instance.ResetScore();
            SceneManager.LoadScene("End");
        }
       
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        
        anim.SetTrigger("hurt");
        Debug.Log("Triggered");
            

    }
}
