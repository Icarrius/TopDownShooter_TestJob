using Leopotam.Ecs;
using UnityEngine;

sealed class EffectsRemovingSystem : IEcsRunSystem
{
    private readonly EcsFilter<RemovedOnFinishEffect> removingEffectsFilter = null;

    public void Run()
    {
        foreach (var entity in removingEffectsFilter)
        {
            ref var effectComponent = ref removingEffectsFilter.Get1(entity);

            ref var particles = ref effectComponent.particles;

            if (particles.gameObject.activeInHierarchy && particles.isStopped)
            {
                particles.gameObject.SetActive(false);
            }
        }
    }
}