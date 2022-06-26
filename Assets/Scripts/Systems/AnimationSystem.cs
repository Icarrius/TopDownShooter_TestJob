using Leopotam.Ecs;
using UnityEngine;

sealed class AnimationSystem : IEcsRunSystem
{
    private readonly EcsFilter<AnimationComponent, ModelComponent, DirectionComponent> animationFilter = null;

    private float velocityX;
    private float velocityZ;

    public void Run()
    {
        foreach (var entity in animationFilter)
        {
            ref var animationComponent = ref animationFilter.Get1(entity);
            ref var modelComponent = ref animationFilter.Get2(entity);
            ref var directionComponent = ref animationFilter.Get3(entity);

            ref var childTransform = ref modelComponent.childTransform;
            ref var animator = ref animationComponent.animatorController;
            ref var direction = ref directionComponent.Direction;

            Vector3 rawDirection = new Vector3(direction.x, 0, direction.z);

            velocityZ = Vector3.Dot(rawDirection.normalized, childTransform.forward);
            velocityX = Vector3.Dot(rawDirection.normalized, childTransform.right);

            animator.SetFloat(animationComponent.velocityX, velocityX, 0.1f, Time.deltaTime);
            animator.SetFloat(animationComponent.velocityZ, velocityZ, 0.1f, Time.deltaTime);
        }
    }
}