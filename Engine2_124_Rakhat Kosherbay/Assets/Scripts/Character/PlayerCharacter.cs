using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public override void Initialize()
    {
        base.Initialize();
        HealthComponent  = new ImmortalHealthComponent();
    }

    protected override void Update()
    {
       if (HealthComponent.Health <= 0)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        MovementComponent.Move(moveDirection);
        MovementComponent.Rotation(moveDirection);
    }
}
