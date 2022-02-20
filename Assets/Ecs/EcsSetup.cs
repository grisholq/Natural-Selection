using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

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

        _systems.ConvertScene();
        _systems.Init();
       
    }

    private void AddSystems()
    {


        _systems.Add(new RestToFoodSearchStateSystem());
        _systems.Add(new FoodSeachToRestStateSystem());
        _systems.Add(new FoodSearchToPersuitStateSystem());
        _systems.Add(new FoodPersuitToRestStateSystem());

        _systems.Add(new FoodSearchSystem());

        _systems.Add(new RestStateStopperSystem());

        _systems.Add(new FoodSearchPatrolStartSystem());
        _systems.Add(new FoodSearchPatrolStopSystem());

        _systems.Add(new FoodPersuitStartSystem());
        _systems.Add(new FoodPersuitStopSystem());

        _systems.Add(new PatrolSystem());
        _systems.Add(new PersuitSystem());

        _systems.Add(new NavAgentDestinationSetSystem());
        _systems.Add(new NavAgentDestinationBlockSystem());
        _systems.Add(new NavAgentStopSystem());

        _systems.Add(new BeingEnergyConsumptionSystem());
        _systems.Add(new EnergyAddSystem());
        _systems.Add(new EnergyDecreaseSystem());

        _systems.Add(new InizializeEntityRequestSystem());
        _systems.Add(new DestroyMonosSystem());
        _systems.Add(new DestroyEntitySystem());
    }

    private void AddOneFrames()
    {
        _systems.OneFrame<NavAgentStopEvent>();
        _systems.OneFrame<NavAgentDestinationEvent>();
        _systems.OneFrame<DestroyEvent>();
    }

    private void Update()
    {
        _systems.Run();
    }
}