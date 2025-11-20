using UnityEngine;

public class AttackComponent : IAttackComponent
{
    private CharacterData data;
    public float Damage => 10f;
    public float AttackRange => 3f;

    public void Initialize(Character character)
    {
        data = character.CharacterData;
    }

    public void MakeDamage(Character attackTarget)
    {
        if (UnityEngine.Vector3.Distance(data.CharacterTransform.position, attackTarget.transform.position) <= AttackRange)
        {
            attackTarget.HealthComponent.SetDamage((int)Damage);
        }
    }
}
