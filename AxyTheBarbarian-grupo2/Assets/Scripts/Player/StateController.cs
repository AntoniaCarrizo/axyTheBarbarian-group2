using UnityEngine;

public class StateController : MonoBehaviour
{
    Player player;
    
    void Start()
    {
        player = GetComponent<Player>();
    }

    public void UpdateState (bool canMove, Vector2 movement)
    {
        if (canMove)
        {
            transform.Translate(movement);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // player.canMove = false;
        }

        if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Enemy")
        {
            player.canMove = false;
        }

        if (collision.gameObject.tag == "Exit")
        {
            player.canMove = false;
        }

        // if (collision.gameObject.tag == "Wall")
        // {
        //     player.canMove = false;
        // }


    }
}
