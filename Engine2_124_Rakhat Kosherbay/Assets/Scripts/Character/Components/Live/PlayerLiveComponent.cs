using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLiveComponent : ILiveComponent
{
    public event Action OnDeath;

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
        OnDeath?.Invoke();
    }
}
