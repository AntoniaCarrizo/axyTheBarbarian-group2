using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float moveSpeedFast;
    public float moveSpeedSlow;

    public Vector2 UpdateMovement((float, float) direction)
    {
        // float currentMoveSpeed = isFastSpeed ? moveSpeedFast : moveSpeedSlow;
        Vector2 movement = new Vector2(direction.Item1, direction.Item2) * 2 * Time.deltaTime;

        return movement;
    }
}