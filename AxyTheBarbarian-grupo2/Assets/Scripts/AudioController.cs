using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class AudioController : MonoBehaviour
{
    public AudioClip collisionSound; // Sonido al colisionar
    private AudioSource audioSource; // Referencia al AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    public void PlayCollisionSound()
    {
        audioSource.Play();
    }
}