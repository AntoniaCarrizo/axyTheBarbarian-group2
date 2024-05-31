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
}
