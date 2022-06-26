using Leopotam.Ecs;
using UnityEngine;

sealed class RotationSystem : IEcsRunSystem
{
    private readonly EcsFilter<AimingDirectonComponent, DirectionComponent, ModelComponent> rotationFilter = null;

    public void Run()
    {
        foreach (var entity in rotationFilter)
        {
            ref var aimingDirectionComponent = ref rotationFilter.Get1(entity);
            ref var directionComponent = ref rotationFilter.Get2(entity);
            ref var modelComponent = ref rotationFilter.Get3(entity);

            ref var aimDirection = ref aimingDirectionComponent.Direction;
            ref var rotationSpeed = ref aimingDirectionComponent.rotationSpeed;

            ref var direction = ref directionComponent.Direction;
            ref var childTransform = ref modelComponent.childTransform;

            Vector3 rawDirection = new Vector3(aimDirection.x, 0, aimDirection.z);

            if(rawDirection == Vector3.zero)
            {
                rawDirection = new Vector3(direction.x, 0, direction.z);
            }

            if (rawDirection == Vector3.zero) continue;

            var lookTo = Quaternion.LookRotation((childTransform.position + rawDirection) - childTransform.position);

            if (lookTo.eulerAngles != Vector3.zero)
                childTransform.rotation = Quaternion.RotateTowards(childTransform.rotation, lookTo, rotationSpeed * Time.deltaTime);
        }
    }
}