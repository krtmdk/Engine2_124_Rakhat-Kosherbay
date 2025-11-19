using UnityEngine;

public class AttackComponent : IAttackComponent
{
    private CharacterData characterData;

    public float Damage => 10;

    public float AttackRange => 3.0f;

    public void Initialize(CharacterData characterData)
    {
      this.characterData = characterData;
    }

    public void MakeDamage(Character attackTarget)
    {
        if (Vector3.Distance(characterData.CharacterTransform.position, attackTarget.transform.position) <= AttackRange) 
            attackTarget.HealthComponent.SetDamage((int)Damage);

    }
}
