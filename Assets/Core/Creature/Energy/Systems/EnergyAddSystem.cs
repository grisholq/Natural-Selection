using Leopotam.Ecs;

public class EnergyAddSystem : IEcsRunSystem
{
    private readonly EcsFilter<EntityComponent, EnergyAddEvent> _addEventsFilter;

    public void Run()
    {
        for (int i = 0; i < _addEventsFilter.GetEntitiesCount(); i++)
        {
            ref var entityComponent = ref _addEventsFilter.Get1(i);
            ref var entity = ref entityComponent.Entity;

            if (entity.Has<EnergyComponent>() == false) continue;

            ref var energyComponent = ref entity.Get<EnergyComponent>();
            var addEvent = _addEventsFilter.Get2(i);

            energyComponent.Energy += addEvent.EnergyAdd;

            _addEventsFilter.GetEntity(i).Destroy();
        }
    }
}
