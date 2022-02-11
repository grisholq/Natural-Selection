using Leopotam.Ecs;

public class EnergyAddSystem : IEcsRunSystem
{
    private readonly EcsFilter<EnergyComponent, EnergyAddEvent> _addEventsFilter;

    public void Run()
    {
        foreach (var i in _addEventsFilter)
        {
            ref var energyComponent = ref _addEventsFilter.Get1(i);
            var addEvent = _addEventsFilter.Get2(i);

            energyComponent.Energy += addEvent.EnergyAdd;

            _addEventsFilter.GetEntity(i).Del<EnergyAddEvent>();
        }
    }
}
