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
        _systems.Add(new CreatureRestStateChangerSystem());

        _systems.Add(new InizializeEntityRequestSystem());

        _systems.Add(new NavAgentSetDestinationSystem());
        _systems.Add(new NavAgentStopSystem());

        _systems.Add(new HealthHealSystem());
        _systems.Add(new HealthDamageSystem());
        _systems.Add(new HealthRegenerationSystem());
        _systems.Add(new HealthDeathSystem());

        _systems.Add(new EnergyAddSystem());
        _systems.Add(new EnergyDecreaseSystem());
    }

    private void AddOneFrames()
    {

    }

    private void Update()
    {
        _systems.Run();
    }
}