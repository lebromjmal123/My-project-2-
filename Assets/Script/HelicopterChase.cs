using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterChase : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;

    private Transform player;
    private HelicopterPatrol patrolScript;
    public AudioSource helicopterSound;
    public bool played;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        patrolScript = GetComponent<HelicopterPatrol>();  // Get the patrol script for switching behaviors
        helicopterSound.Play();
    }

    void Update()
    {
        if (PauseMenu.GameIsPaused == true)
        {
            helicopterSound.Stop();
            
            played = true;

        }
        else if (PauseMenu.GameIsPaused == false)
        {
            if (played == true)
            { 
            helicopterSound.Play();
            
            played = false;
            }
        }
        

        


        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            
            // Stop the patrol behavior and start chasing
            patrolScript.StopPatrolling();
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }


        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            
            // Shoot at the player
            
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
        //else
        //{
        // If player is out of sight, stop chasing and let patrol handle returning to original position
        // patrolScript.StartPatrolling();
        //}
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
