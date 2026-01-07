using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILiveComponent : ICharacterComponent
{
    public event Action<Character> OnCharacterDeath;

    public event Action OnDeath;


    public bool IsAlive { get; }
   public int MaxHealth { get; }
    public float Health { get; }


    public void GetDamage(float damage);
}
