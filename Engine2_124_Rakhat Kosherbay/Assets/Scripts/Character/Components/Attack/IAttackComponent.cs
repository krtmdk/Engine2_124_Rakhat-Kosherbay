public interface IAttackComponent
{
    float Damage { get; }
    void Initialize(Character character);
    void MakeDamage(Character target);
}
