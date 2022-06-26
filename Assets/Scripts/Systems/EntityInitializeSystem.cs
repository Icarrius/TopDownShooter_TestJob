using Leopotam.Ecs;

public class EntityInitializeSystem : IEcsRunSystem
{
    private readonly EcsFilter<InitializeEntityRequest> initFilter = null;

    public void Run()
    {
        foreach(var _entity in initFilter)
        {
            ref var entity = ref initFilter.GetEntity(_entity);
            ref var request = ref initFilter.Get1(_entity);

            request.entityReference.Entity = entity;
        }
    }
}