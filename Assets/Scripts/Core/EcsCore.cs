using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsCore : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;
    private EcsSystems fixedRunSystems;

    #region Unity_Calls
    private void Start()
    {
        Application.targetFrameRate = 60;

        world = new EcsWorld();
        systems = new EcsSystems(world);
        fixedRunSystems = new EcsSystems(world);

        systems.ConvertScene();

        AddInjections();
        AddSystems();
        AddFixedSystems();
        AddOneFrames();

        systems.Init();
        fixedRunSystems.Init();
    }

    private void Update()
    {
        systems.Run();
    }

    private void FixedUpdate()
    {
        fixedRunSystems.Run();
    }

    private void OnDestroy()
    {
        if(systems != null)
        {
            systems.Destroy();
            systems = null;
        }

        if(fixedRunSystems != null)
        {
            fixedRunSystems.Destroy();
            fixedRunSystems = null;
        }

        world.Destroy();
        world = null;
    }
    #endregion

    #region Private_Variables
    private void AddInjections()
    {
        
    }

    private void AddSystems()
    {
        systems.
            Add(new EntityInitializeSystem()).
            Add(new PlayerInputSystem()).
            Add(new RotationSystem()).
            Add(new AnimationSystem()).
            Add(new ShootingSystem()).
            Add(new EffectsRemovingSystem()).
            Add(new MovementSystem())
        ;
    }

    private void AddFixedSystems()
    {
        fixedRunSystems.
            Add(new AimingSystem());

    }

    private void AddOneFrames()
    {
        systems.
            OneFrame<InitializeEntityRequest>()
        ;
    }

    #endregion
}