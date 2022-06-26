using Leopotam.Ecs;
using UnityEngine;

sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsFilter<MovementComponent, DirectionComponent, ModelComponent> movementFilter = null; 

    public void Run()
    {
        foreach(var entity in movementFilter)
        {
            ref var movementComponent = ref movementFilter.Get1(entity);
            ref var directionComponent = ref movementFilter.Get2(entity);
            ref var modelComponent = ref movementFilter.Get3(entity);

            ref var direction = ref directionComponent.Direction;
            ref var transform = ref modelComponent.childTransform;

            ref var mainTransform = ref movementComponent.mainTransform;
            ref var characterController = ref movementComponent.characterController;
            ref var speed = ref movementComponent.movementSpeed;

            Vector3 rawDirection = new Vector3(direction.x, 0, direction.z);

            ref var velocity = ref movementComponent.velocity;
            velocity.y += movementComponent.gravity * Time.deltaTime;

            characterController.Move(rawDirection * Time.deltaTime * speed);
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}