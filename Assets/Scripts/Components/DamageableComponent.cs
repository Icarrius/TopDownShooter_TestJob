using System;
using UnityEngine;

[Serializable]
public struct DamageableComponent : IDamageable
{
    [SerializeField]
    private int maxHealth;

    public int MaxHealth => maxHealth;

    public int CurrentHealth => _currentHealth;

    private int _currentHealth;

    public void TakeDamage(int damageValue)
    {
        _currentHealth = Mathf.Clamp(CurrentHealth - damageValue, 0, MaxHealth);
    }
}