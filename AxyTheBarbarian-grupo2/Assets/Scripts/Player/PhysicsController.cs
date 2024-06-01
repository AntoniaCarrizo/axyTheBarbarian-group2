using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    public Vector2 UpdateMovement(Vector2 direction, float speed)
    {
        Vector2 movement = direction * speed * Time.deltaTime;
        return movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || 
            collision.gameObject.CompareTag("Enemy") || 
            collision.gameObject.CompareTag("Exit"))
        {
            player.canMove = false;
        }
    }
}