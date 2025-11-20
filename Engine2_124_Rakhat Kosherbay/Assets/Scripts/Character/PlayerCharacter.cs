using UnityEngine;

public class PlayerCharacter : Character
{
    private IInputReader inputReader;

    public override void Initialize()
    {
        base.Initialize();
        HealthComponent = new ImmortalHealthComponent();
        inputReader = new PlayerInputReader();
    }

    protected override void Update()
    {
        if (HealthComponent.Health <= 0) return;

        UnityEngine.Vector3 moveDirection = inputReader.ReadInput();
        MovementComponent.Move(moveDirection);
        MovementComponent.Rotation(moveDirection);
    }
}
