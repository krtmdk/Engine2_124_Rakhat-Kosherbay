public interface IAttackComponent
{
    float Damage { get; }
    float AttackRange { get; }
    void Initialize(Character character);
    void MakeDamage(Character attackTarget);
}
