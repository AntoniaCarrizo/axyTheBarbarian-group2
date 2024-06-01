using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class AudioController : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayCollisionSound()
    {
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}