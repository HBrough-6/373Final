using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnce : MonoBehaviour
{
    private bool hasPlayed = false; // Tracks whether the audio has already been played

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component on this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on this object.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is tagged as "Player" and audio hasn't played yet
        if (other.CompareTag("Player") && !hasPlayed)
        {
            // Play the audio clip
            audioSource.Play();

            // Set the flag to true so the audio won't play again
            hasPlayed = true;
        }
    }
}
