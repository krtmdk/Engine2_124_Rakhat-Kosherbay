using UnityEngine;

public interface IMovementComponent
{
    float Speed { get; set; }
    UnityEngine.Vector3 Position { get; }
    void Initialize(Character character);
    void Move(UnityEngine.Vector3 direction);
    void Rotation(UnityEngine.Vector3 direction);
}
