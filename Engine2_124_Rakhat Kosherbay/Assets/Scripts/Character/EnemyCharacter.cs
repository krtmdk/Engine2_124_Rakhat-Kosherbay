using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private Character targetCharacter;
    [SerializeField] private AiState aiState = AiState.MoveToTarget;

    public override void Start()
    {
        base.Start();

        LiveComponent = new EnemyLiveComponent();
        AttackComponent = new CharacterAttackComponent();

        AttackComponent.Initialize(this);
    }

    public override void Update()
    {
        if (LiveComponent == null || !LiveComponent.IsAlive) return;
        if (targetCharacter == null) return;

        float distance = Vector3.Distance(targetCharacter.transform.position, CharacterData.CharacterTransform.position);

        switch (aiState)
        {
            case AiState.None:
                return;

            case AiState.MoveToTarget:
                Move();

                if (distance <= 3f)
                    aiState = AiState.Attack;

                return;

            case AiState.Attack:
                if (distance > 3f)
                {
                    aiState = AiState.MoveToTarget;
                    return;
                }

                AttackComponent.MakeDamage(targetCharacter);
                return;
        }
    }

    private void Move()
    {
        if (targetCharacter == null) return;

        Vector3 direction = targetCharacter.transform.position - CharacterData.CharacterTransform.position;
        direction.y = 0;
        direction = direction.normalized;

        MovableComponent.Move(direction);
        MovableComponent.Rotation(direction);
    }
}
