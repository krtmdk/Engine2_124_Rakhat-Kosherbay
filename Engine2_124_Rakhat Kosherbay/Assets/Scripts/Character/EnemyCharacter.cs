using UnityEngine;

public class EnemyCharacter : Character
{
   
    [SerializeField] private AiState aiState = AiState.MoveToTarget;

    public override Character CharacterTarget => 
        GameManager.Instance.CharacterFactory.Player;

    public override void Initialize()
    {
        base.Initialize();

        LiveComponent = new EnemyLiveComponent();
        LiveComponent.Initialize(this);

        AttackComponent = new CharacterAttackComponent();
        AttackComponent.Initialize(this);
    }

    public override void Update()
    {
        if (LiveComponent == null || !LiveComponent.IsAlive) return;
        if (CharacterTarget == null) return;

        float distance = Vector3.Distance(CharacterTarget.transform.position, CharacterData.CharacterTransform.position);

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

                AttackComponent.MakeDamage(CharacterTarget);
                return;
        }
    }

    private void Move()
    {
        if (CharacterTarget == null) return;

        Vector3 direction = CharacterTarget.transform.position - CharacterData.CharacterTransform.position;
        direction.y = 0;
        direction = direction.normalized;

        MovableComponent.Move(direction);
        MovableComponent.Rotation(direction);
    }
}
