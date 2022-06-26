using System;
using UnityEngine;

[Serializable]
public struct ShootingComponent
{
    public float attackCooldown;
    public int damageValue;
    public ParticleSystem flashParticles;

    public float NextShootTime { get; set; }
}