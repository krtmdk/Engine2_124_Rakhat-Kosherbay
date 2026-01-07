using System;
using UnityEngine;

public class EnemyLiveComponent : ILiveComponent
{
    private float health;
    private Character selfCharacter;

    public bool IsAlive => Health > 0;

    public int MaxHealth => 10;

    public float Health
    {
        get => health;
        private set
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                OnDeath?.Invoke();
                OnCharacterDeath?.Invoke(selfCharacter);
            }
        }
    }

    public event Action OnDeath;
    public event Action<Character> OnCharacterDeath;

    public void GetDamage(float damage)
    {
        Health -= damage;
    }

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
    }
}
