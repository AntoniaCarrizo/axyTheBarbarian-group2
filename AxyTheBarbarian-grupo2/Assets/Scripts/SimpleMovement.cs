using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeedSlow = 4f; //velocidad lenta
    public float moveSpeedFast = 8f; //velocidad rápida
    private bool isFastSpeed = false; //ayuda para cambiar la velocidad
    public AudioClip collisionSound; // Sonido al colisionar
    private AudioSource audioSource; // Referencia al AudioSource

    void Start()
    {
        // Obtener el AudioSource del jugador
        audioSource = GetComponent<AudioSource>();
        // Asignar el AudioClip al AudioSource desde el Inspector
        audioSource.clip = collisionSound;
    }
    void Update()
    {
        HandleInput();
        UpdateMovement();
        UpdateColors();
    }

    void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFastSpeed = !isFastSpeed;
        }
    }

    void UpdateMovement()
    {
        float currentMoveSpeed = isFastSpeed ? moveSpeedFast : moveSpeedSlow;
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * currentMoveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void UpdateColors()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Camera.main.backgroundColor = Random.ColorHSV();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }

    // Método para detectar colisiones 2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con un objeto que tenga el tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Aquí puedes añadir acciones cuando colisiona con un enemigo, como reducir la salud del jugador, reproducir un sonido, etc.
            Debug.Log("Colisión con un enemigo");
            audioSource.Play();
        }

        // Si colisiona con un objeto que tenga el tag "Wall"
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Aquí puedes añadir acciones cuando colisiona con una pared, como detener el movimiento del jugador, reproducir un sonido, etc.
            Debug.Log("Colisión con una pared");
            audioSource.Play();
        }
    }
}
