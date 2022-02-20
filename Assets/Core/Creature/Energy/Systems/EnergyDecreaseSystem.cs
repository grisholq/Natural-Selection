using Leopotam.Ecs;

public class EnergyDecreaseSystem : IEcsRunSystem
{
    private readonly EcsFilter<EntityComponent, EnergyDecreaseEvent> _decreaseEventsFilter;

    public void Run()
    {
        foreach (var i in _decreaseEventsFilter)
        {
            ref var entityComponent = ref _decreaseEventsFilter.Get1(i);
            ref var entity = ref entityComponent.Entity;

            if (entity.Has<EnergyComponent>() == false) continue;

            ref var energyComponent = ref entity.Get<EnergyComponent>();
            var decreaseEvent = _decreaseEventsFilter.Get2(i);

            energyComponent.Energy += decreaseEvent.EnergyDecrease;

            entity.Destroy();
        }
    }
}
