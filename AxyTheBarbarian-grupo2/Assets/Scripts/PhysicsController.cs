using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float moveSpeedFast;
    public float moveSpeedSlow;

    public void UpdateMovement(bool isFastSpeed)
    {
        float currentMoveSpeed = isFastSpeed ? moveSpeedFast : moveSpeedSlow;
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * currentMoveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}