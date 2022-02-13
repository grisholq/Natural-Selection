using UnityEngine;
using Leopotam.Ecs;

public class EcsSetup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Awake()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        AddSystems();
        AddOneFrames();
    }

    private void AddSystems()
    {
        _systems.Add(new RestToFoodSearchStateSystem());
        _systems.Add(new FoodSeachToRestStateSystem());
        _systems.Add(new FoodSearchToPersuitStateSystem());
        _systems.Add(new FoodPersuitToRestStateSystem());

        _systems.Add(new PatrolSystem());
        _systems.Add(new PersuitSystem());

        _systems.Add(new NavAgentSetDestinationSystem());
        _systems.Add(new NavAgentStopSystem());

        _systems.Add(new EnergyAddSystem());
        _systems.Add(new EnergyDecreaseSystem());

        _systems.Add(new InizializeEntityRequestSystem());
    }

    private void AddOneFrames()
    {

    }

    private void Update()
    {
        _systems.Run();
    }
}