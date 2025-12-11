using UnityEngine;

public class CharacterAttackComponent : IAttackComponent
{
    private Transform characterTransform;
    private float lockDamageTime = 0;
    public float Damage => 5;

    public void Initialize(Character character)
    {
        if (character != null && character.CharacterData != null)
            characterTransform = character.CharacterData.CharacterTransform;
        else if (character != null)
            characterTransform = character.transform;
    }

    public void MakeDamage(Character target)
    {
        if (target == null) return;
        if (target.LiveComponent == null) return;
        if (!target.LiveComponent.IsAlive) return;

        if (characterTransform == null) return;

        if (Vector3.Distance(target.transform.position, characterTransform.position) > 3f) return;

        if (lockDamageTime > 0)
        {
            lockDamageTime -= Time.deltaTime;
            return;
        }

        target.LiveComponent.GetDamage(Damage);
        lockDamageTime = 1f;
    }
}
