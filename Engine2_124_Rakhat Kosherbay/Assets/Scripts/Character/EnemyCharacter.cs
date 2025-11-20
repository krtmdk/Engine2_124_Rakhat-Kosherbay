using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private Character characterTarget;
    [SerializeField] private AiState aiState;

    public override void Initialize()
    {
        base.Initialize();
        HealthComponent = new HealthComponent();
    }

    protected override void Update()
    {
        if (HealthComponent.Health <= 0) return;

        float distance = UnityEngine.Vector3.Distance(transform.position, characterTarget.transform.position);

        switch (aiState)
        {
            case AiState.Idle:
                return;

            case AiState.MoveToTarget:
                if (distance <= AttackComponent.AttackRange)
                {
                    aiState = AiState.Attack;
                    return;
                }
                UnityEngine.Vector3 moveDirection = (characterTarget.transform.position - transform.position).normalized;
                MovementComponent.Move(moveDirection);
                MovementComponent.Rotation(moveDirection);
                return;

            case AiState.Attack:
                if (distance > AttackComponent.AttackRange)
                {
                    aiState = AiState.MoveToTarget;
                    return;
                }
                AttackComponent.MakeDamage(characterTarget);
                return;
        }
    }
}
