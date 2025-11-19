using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalHealthComponent : IHealthComponent
{
    public float Health => 100;

    public float MaxHealth => 100;

    public void SetDamage(int damage)
    {
        Debug.Log("You are stupid, i'm immortal!");
    }
}
