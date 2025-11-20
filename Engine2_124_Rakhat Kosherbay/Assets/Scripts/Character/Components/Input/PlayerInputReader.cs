using UnityEngine;

public class PlayerInputReader : IInputReader
{
    public UnityEngine.Vector3 ReadInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        return new UnityEngine.Vector3(h, 0f, v).normalized;
    }
}
