using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float moveSpeedFast;
    public float moveSpeedSlow;

    public void UpdateMovement(bool isFastSpeed, (float, float) direction)
    {
        float currentMoveSpeed = isFastSpeed ? moveSpeedFast : moveSpeedSlow;
        Vector2 movement = new Vector2(direction.Item1, direction.Item2) * currentMoveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}