using Leopotam.Ecs;

public class EnergyDecreaseSystem : IEcsRunSystem
{
    private readonly EcsFilter<EnergyComponent, EnergyDecreaseEvent> _decreaseEventsFilter;

    public void Run()
    {
        foreach (var i in _decreaseEventsFilter)
        {
            ref var energyComponent = ref _decreaseEventsFilter.Get1(i);
            var decreaseEvent = _decreaseEventsFilter.Get2(i);

            energyComponent.Energy += decreaseEvent.EnergyDecrease;

            _decreaseEventsFilter.GetEntity(i).Del<EnergyDecreaseEvent>();
        }
    }
}
