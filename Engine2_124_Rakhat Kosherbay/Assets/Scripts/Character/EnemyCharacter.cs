using UnityEngine;

public class EnemyCharacter : Character
{

    [SerializeField]
    private Character characterTarget;
    [SerializeField]
    private AiState aiState;

    public override void Initialize()
    {
       base.Initialize();
        HealthComponent = new HealthComponent();
    }

    protected override void Update()                                                            
    {
        if (HealthComponent.Health <= 0)
            return;

        switch (aiState) 
        {
            case AiState.Idle:
                return;

            case AiState.MoveToTarget:
                Vector3 moveDirection = characterTarget.transform.position - transform.position;
                moveDirection.Normalize();


                MovementComponent.Move(moveDirection);
                MovementComponent.Rotation(moveDirection);

                AttackComponent.MakeDamage(characterTarget);

                return;
        }
    }
}
