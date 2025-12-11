using UnityEngine;

public class PlayerInputReader : MonoBehaviour, IInputReader
{
    public Vector3 GetMovementDirection()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        return new Vector3(moveHorizontal, 0, moveVertical).normalized;
    }
}
