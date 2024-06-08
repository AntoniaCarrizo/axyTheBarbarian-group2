using UnityEngine;

public class CowardRat : MonoBehaviour
{
    public float wanderRadius = 10f;
    public float fleeDistance = 5f;
    private Transform playerObject; // Reference to the player object

    public GameObject player;

    void Start()
    {
        // Get the player reference using a tag
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            playerObject = player.transform;
        }
        else
        {
            Debug.LogError("No GameObject found with tag 'Player'.");
            return;
        }
    }

    void Update()
    {
        // Try to find the player every frame until it's found
        if (playerObject == null)
        {
            GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
            
            if (playerGameObject != null)
            {
                playerObject = playerGameObject.transform;
            }
            else
            {
                Debug.LogError("No GameObject found with tag 'Player'.");
            }
        }

        // Skip the rest of the Update if no player is found
        if (playerObject == null)
        {
            return;
        }

        // Wander
        Vector3 randomPosition = Random.insideUnitSphere * wanderRadius;
        transform.position += randomPosition * Time.deltaTime;

        // Flee
        float distanceToPlayer = Vector3.Distance(transform.position, playerObject.position);
        if (distanceToPlayer <= fleeDistance)
        {
            // Calculate the direction away from the player
            Vector3 directionAwayFromPlayer = (transform.position - playerObject.position).normalized;
            transform.position += directionAwayFromPlayer * Time.deltaTime * 5;
        }
    }
}