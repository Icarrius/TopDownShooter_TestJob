using Leopotam.Ecs;
using UnityEngine;

sealed class ShootingSystem : IEcsRunSystem
{
    private readonly EcsFilter<ShootingComponent, TargetingComponent> shootingFilter = null;

    public void Run()
    {
        foreach (var entity in shootingFilter)
        {
            ref var shootingComponent = ref shootingFilter.Get1(entity);
            ref var targetingComponent = ref shootingFilter.Get2(entity);

            if(targetingComponent.CurrentTarget != null && Time.time > shootingComponent.NextShootTime)
            {
                shootingComponent.NextShootTime = Time.time + shootingComponent.attackCooldown;

                ParticleSystem hitEffect = EffectsPool.SharedInstance.GetPooledObject();

                if(hitEffect != null)
                {
                    shootingComponent.flashParticles.Stop();
                    shootingComponent.flashParticles.Play();

                    hitEffect.transform.position = targetingComponent.HitInfo.point;
                    hitEffect.gameObject.SetActive(true);
                    hitEffect.Play();
                }
            }
        }
    }
}