using UnityEngine;

public class RatWandering : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionTime = 3f;
    public float detectionRadius = 5f;
    public GameObject player;

    private Vector2 movementDirection;
    private float changeDirectionTimer;
    private bool isRunningAway = false;

    void Start()
    {
        ChangeDirection();
        changeDirectionTimer = changeDirectionTime;
    }

    void Update()
    {
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
            RunAway();
        }
    }

    void ChangeDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        movementDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
        Debug.Log("Changing Direction: " + movementDirection);
    }

    void Move()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    void RunAway()
    {
        Vector2 directionAwayFromPlayer = (transform.position - player.transform.position).normalized;
        movementDirection = directionAwayFromPlayer; // Set movementDirection to the opposite direction of the player
        isRunningAway = true;
        Debug.Log("Running Away: " + directionAwayFromPlayer);
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