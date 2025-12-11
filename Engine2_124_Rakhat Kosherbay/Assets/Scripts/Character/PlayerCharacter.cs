using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] private PlayerInputReader inputReader;

    public override void Start()
    {
        base.Start();
        LiveComponent = new PlayerLiveComponent();
    }

    public override void Update()
    {
        if (LiveComponent == null || !LiveComponent.IsAlive) return;

        Vector3 movementVector = Vector3.zero;
        if (inputReader != null)
            movementVector = inputReader.GetMovementDirection();

        MovableComponent.Move(movementVector);
        MovableComponent.Rotation(movementVector);
    }
}
