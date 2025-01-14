using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundMoving : MonoBehaviour
{
    public AudioClip[] movementSounds; // Array of sounds to play
    public AudioSource audioSource;    // AudioSource to play sounds
    public float cooldown = 2f;        // Cooldown time in seconds between sounds

    private Vector2 lastPosition;
    private float cooldownTimer;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        lastPosition = transform.position;
        cooldownTimer = 0f;
    }

    void Update()
    {
        // Check if the character is moving
        if (IsMoving() && cooldownTimer <= 0f)
        {
            PlayRandomSound();
            cooldownTimer = cooldown;
        }

        // Reduce the cooldown timer
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    bool IsMoving()
    {
        // Check if the position has changed on the X or Y axis
        Vector2 currentPosition = transform.position;
        bool moving = currentPosition != lastPosition;
        lastPosition = currentPosition;
        return moving;
    }

    void PlayRandomSound()
    {
        if (movementSounds.Length == 0) return;

        int randomIndex = Random.Range(0, movementSounds.Length);
        AudioClip clip = movementSounds[randomIndex];

        audioSource.clip = clip;
        audioSource.Play();
    }
}
