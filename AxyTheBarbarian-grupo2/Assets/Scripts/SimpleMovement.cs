using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeedSlow = 4f; //velocidad lenta
    public float moveSpeedFast = 8f; //velocidad rápida
    private bool isFastSpeed = false; //ayuda para cambiar la velocidad
    public AudioClip collisionSound; // Sonido al colisionar
    private AudioSource audioSource; // Referencia al AudioSource

    InputComponent inputComponent;

    void Start()
    {
        //obtener componente de audio
        audioSource = GetComponent<AudioSource>();
        //asignar el audio
        audioSource.clip = collisionSound;

        inputComponent = GetComponent<InputComponent>();
    }
    void Update()
    {
        (float, float) direction = inputComponent.HandleInput();
        UpdateMovement(direction);
        UpdateColors();
    }

    void UpdateMovement((float, float) direction)
    {
        // float currentMoveSpeed = isFastSpeed ? moveSpeedFast : moveSpeedSlow;
        float currentMoveSpeed = moveSpeedSlow;
        Vector2 movement = new Vector2(direction.Item1, direction.Item2) * currentMoveSpeed * Time.deltaTime;
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

    //para colisiones
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Colisión con un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Colisión con un enemigo");
            audioSource.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena
        }

        // Colisión con una flecha
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Debug.Log("Colisión con una flecha");
            audioSource.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena
        }

        // Colisión con una pared
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Colisión con una pared");
            audioSource.Play();
        }

        if (collision.gameObject.CompareTag("Exit"))
        {
            Debug.Log("Colisión con el objeto de salida, Ganaste!!");
            // SceneManager.LoadScene("VictoryScene"); // Carga la escena de victoria
        }

    }
}
