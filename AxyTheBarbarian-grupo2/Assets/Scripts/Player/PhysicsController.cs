using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PhysicsController : MonoBehaviour
{
    Player player;
    AudioController audioController;

    void Start()
    {
        player = GetComponent<Player>();
        audioController = GetComponent<AudioController>();

        GameObject newObserver = new GameObject("ObserverObject");
        GlobalListener observerScript = newObserver.AddComponent<GlobalListener>();
    }

    public Vector2 UpdateMovement(Vector2 direction, float speed)
    {
        Vector2 movement = direction * speed * Time.deltaTime;
        return movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || 
            collision.gameObject.CompareTag("Enemy"))
        {
            player.canMove = false;
            GlobalListener.Instance.ReloadLevel();
        }

        if (collision.gameObject.CompareTag("Exit"))
        {
            player.canMove = false;
            GlobalListener.Instance.ReloadLevel();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            audioController.PlayCollisionSound();
        }
    }
}