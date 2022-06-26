using Leopotam.Ecs;
using UnityEngine;

sealed class AimingSystem : IEcsRunSystem
{
    private readonly EcsFilter<TargetingComponent, ModelComponent> targetingFilter = null;

    public void Run()
    {
        foreach (var entity in targetingFilter)
        {
            ref var targetingComponent = ref targetingFilter.Get1(entity);
            ref var modelComponent = ref targetingFilter.Get2(entity);

            ref var childTransform = ref modelComponent.childTransform;
            ref var rectAim = ref targetingComponent.aimRectTransform;

            RaycastHit hit;
            Vector3 positionOfAim;

            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(childTransform.position + targetingComponent.RaycastOffset, childTransform.TransformDirection(Vector3.forward), out hit, targetingComponent.aimMaxRange, layerMask))
            {
                targetingComponent.HitInfo = hit;
                positionOfAim = hit.point;

                var hitEntityRef = hit.collider.GetComponent<EntityReference>();

                DamageableComponent damageable;

                if (hitEntityRef != null && hitEntityRef.Entity.Has<DamageableComponent>())
                {
                    damageable = hitEntityRef.Entity.Get<DamageableComponent>();
                    targetingComponent.aimImage.color = targetingComponent.aimColors.aimedColor; 
                    targetingComponent.CurrentTarget = damageable;
                }
                else
                {
                    targetingComponent.aimImage.color = targetingComponent.aimColors.collidedColor;
                    targetingComponent.CurrentTarget = null;
                }            
            }
            else
            {
                positionOfAim = childTransform.position + childTransform.TransformDirection(Vector3.forward) * targetingComponent.aimMaxRange;

                targetingComponent.CurrentTarget = null;
                targetingComponent.aimImage.color = targetingComponent.aimColors.neutralColor;
            }

            rectAim.position = Camera.main.WorldToScreenPoint(positionOfAim);
        }
    }
}