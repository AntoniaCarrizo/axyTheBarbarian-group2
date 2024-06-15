using UnityEngine;
using System;

public class CowardRat : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionTime = 3f;
    public float detectionRadius = 5f;
    public GameObject player;

    private Vector2 movementDirection;
    private float changeDirectionTimer;
    private bool isRunningAway; // Declarar isRunningAway aquí

    // Árbol de decisiones
    private DecisionNode rootNode;

    void Start()
    {
        // Configurar el árbol de decisiones
        rootNode = new PlayerNearNode(
            gameObject,
            player,
            detectionRadius,
            new RunAwayNode(gameObject, player, movementDirection, isRunningAway), 
            new InactiveNode()
        );

        ChangeDirection();
        changeDirectionTimer = changeDirectionTime;
    }
    void Update()
    {
        // Evaluar el árbol de decisiones
        isRunningAway = rootNode.Evaluate();

        if (isRunningAway)
        {
            Move();
            return;
        }

        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer <= 0)
        {
            ChangeDirection();
            changeDirectionTimer = changeDirectionTime;
        }

        Move();

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log("Distance to Player: " + distanceToPlayer);

        if (distanceToPlayer < detectionRadius)
        {
            Debug.Log("Player detected within radius");
            SetRunningAway(true);
        }
    }

    void ChangeDirection()
    {
        float randomAngle = UnityEngine.Random.Range(0f, 360f);
        movementDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
        Debug.Log("Changing Direction: " + movementDirection);
    }

    void Move()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    void SetRunningAway(bool value)
    {
        isRunningAway = value;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collided with Wall: " + collision.gameObject.name);
            ChangeDirection();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}