using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCollision : MonoBehaviour
{
    public AudioSource miss; // AudioSource component to play the miss sound
    public ScoreManager ScoreManager; // Reference to the ScoreManager for tracking misses
    
    public void OnCollisionEnter(Collision other)
    {
        // Check if the colliding object has the tag "Ball"
        if (other.gameObject.tag == "Ball")
        {
            // Play the miss sound
            miss.Play();

            // Increment the miss count using the ScoreManager
            ScoreManager.IncrementMisses();
        }
    }
}

