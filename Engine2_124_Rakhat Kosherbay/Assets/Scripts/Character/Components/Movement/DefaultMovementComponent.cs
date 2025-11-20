using UnityEngine;

public class DefaultMovementComponent : IMovementComponent
{
    private CharacterData data;
    private float speed;

    public float Speed
    {
        get => speed;
        set => speed = value <= 0 ? 0 : value;
    }

    public UnityEngine.Vector3 Position => data.CharacterTransform.position;

    public void Initialize(Character character)
    {
        data = character.CharacterData;
        Speed = data.DefaultSpeed;
    }

    public void Move(UnityEngine.Vector3 direction)
    {
        if (direction == UnityEngine.Vector3.zero) return;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        UnityEngine.Vector3 movement = Quaternion.Euler(0, targetAngle, 0) * UnityEngine.Vector3.forward;
        data.CharacterController.Move(movement * Speed * Time.deltaTime);
    }

    public void Rotation(UnityEngine.Vector3 direction)
    {
        if (direction == UnityEngine.Vector3.zero) return;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float vel = 0f;
        float angle = Mathf.SmoothDampAngle(
            data.CharacterTransform.eulerAngles.y,
            targetAngle,
            ref vel,
            0.1f
        );
        data.CharacterTransform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
