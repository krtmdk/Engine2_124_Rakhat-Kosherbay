using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLiveComponent : ILiveComponent
{
    Character selfCharacter;
    public event Action OnDeath;
    public event Action<Character> OnCharacterDeath;

    private float health = 50;

    public bool IsAlive => 
        health > 0;

    public int MaxHealth => 50;
    public float Health
    {
        get => health;
        private set
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                SetDeath();
            }
        }

    }

    

    public void GetDamage(float damage)
    {
        Health -= damage;
        Debug.LogError($"Игрок получил урон в количестве {damage}. Оставшиеся жизни {Health}");
    }

    private void SetDeath()
    {
        OnCharacterDeath?.Invoke(selfCharacter);
        OnDeath?.Invoke();
    }

    public void Initialize(Character selfCharacter) 
    { 
        this.selfCharacter = selfCharacter; 
    }

}
