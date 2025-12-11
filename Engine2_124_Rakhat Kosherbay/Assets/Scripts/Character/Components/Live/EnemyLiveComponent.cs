using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLiveComponent : ILiveComponent
{

    private float health;

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
            }
        }

    }

    public event Action OnDeath;

    public void GetDamage(float damage)
    {
        Health -= damage * 1000;
    }
}
