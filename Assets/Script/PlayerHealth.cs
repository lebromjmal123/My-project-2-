using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount;
    private Animator anim;
    public bool hpTrigger;
    

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
            SceneManager.LoadScene("End");
        }
       
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;

        if (damage > 0)
        {
            Debug.Log("Triggered");
            hpTrigger = true;
            StartCoroutine(Hurt());
        }
    }

    IEnumerator Hurt()
    {

        anim.SetBool("hurt", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("hurt", false);
    }


}
