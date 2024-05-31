using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public (float, float) direction;
    public Vector2 movement;
    public bool canMove = true;

    InputController inputController;
    PhysicsController physicsController;
    StateController stateController;

    void Start()
    {
        inputController = GetComponent<InputController>();
        physicsController = GetComponent<PhysicsController>();
        stateController = GetComponent<StateController>();
    }

    void Update()
    {
        direction = inputController.HandleInput();
        movement = physicsController.UpdateMovement(direction);
        stateController.UpdateState(canMove, movement);
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

    // //para colisiones
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // Colisión con un enemigo
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         Debug.Log("Colisión con un enemigo");
    //         audioController.PlayCollisionSound();
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena
    //     }

    //     // Colisión con una flecha
    //     if (collision.gameObject.CompareTag("Arrow"))
    //     {
    //         Debug.Log("Colisión con una flecha");
    //         audioController.PlayCollisionSound();
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena
    //     }

    //     // Colisión con una pared
    //     if (collision.gameObject.CompareTag("Wall"))
    //     {
    //         Debug.Log("Colisión con una pared");
    //         audioController.PlayCollisionSound();

    //     }

    //     if (collision.gameObject.CompareTag("Exit"))
    //     {
    //         Debug.Log("Colisión con el objeto de salida, Ganaste!!");
    //         // SceneManager.LoadScene("VictoryScene"); // Carga la escena de victoria
    //     }

    // }
}