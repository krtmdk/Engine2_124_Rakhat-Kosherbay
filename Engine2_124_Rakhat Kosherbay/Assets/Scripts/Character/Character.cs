using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected CharacterData characterData;

    public CharacterData CharacterData => characterData;

    public IMovable MovableComponent { get; protected set; }
    public ILiveComponent LiveComponent { get; protected set; }
    public IAttackComponent AttackComponent { get; protected set; }

    public virtual void Start()
    {
        MovableComponent = new CharacterMovementComponent();

        MovableComponent.Initialize(this);
    }

    public abstract void Update();
}
