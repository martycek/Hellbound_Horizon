using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;

    void Start()
    {
        // Check if an AudioSource component is attached
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If no AudioSource component is found, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the background music to the AudioSource
        audioSource.clip = backgroundMusic;

        // Configure AudioSource settings (loop, volume, etc.)
        audioSource.loop = true;
        audioSource.volume = 0.5f; // Adjust volume as needed

        // Play the background music
        audioSource.Play();
    }
}
