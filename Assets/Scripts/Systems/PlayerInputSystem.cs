using Leopotam.Ecs;

sealed class PlayerInputSystem : IEcsRunSystem
{

    private readonly EcsFilter<PlayerTag, DirectionComponent, AimingDirectonComponent> directionFilter = null;

    private float xMovementDirection;
    private float zMovementDirection;

    private float xAimingDirection;
    private float zAimingDirection;

    public void Run()
    {
        UpdateMovementDirection();
        UpdateAimingDirection();

        foreach (var entity in directionFilter)
        {
            ref var directionComponent = ref directionFilter.Get2(entity);
            ref var movementDirection = ref directionComponent.Direction;

            ref var aimingDirectionComponent = ref directionFilter.Get3(entity);
            ref var aimingDirection = ref aimingDirectionComponent.Direction;

            movementDirection.x = xMovementDirection;
            movementDirection.z = zMovementDirection;

            aimingDirection.x = xAimingDirection;
            aimingDirection.z = zAimingDirection;
        }
    }

    private void UpdateMovementDirection()
    {
        xMovementDirection = UltimateJoystick.GetHorizontalAxis("Movement");
        zMovementDirection = UltimateJoystick.GetVerticalAxis("Movement");
    }

    private void UpdateAimingDirection()
    {
        xAimingDirection = UltimateJoystick.GetHorizontalAxis("Rotation");
        zAimingDirection = UltimateJoystick.GetVerticalAxis("Rotation");
    }

}