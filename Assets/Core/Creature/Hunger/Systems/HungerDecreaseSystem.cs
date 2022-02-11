using Leopotam.Ecs;

public class HungerDecreaseSystem : IEcsRunSystem
{
    private readonly EcsFilter<HungerComponent, HungerDecreaseEvent> _decreaseEventsFilter;

    public void Run()
    {
        foreach (var i in _decreaseEventsFilter)
        {
            ref var hungerComponent = ref _decreaseEventsFilter.Get1(i);
            var decreaseEvent = _decreaseEventsFilter.Get2(i);

            hungerComponent.Hunger -= decreaseEvent.HungerDecrease;

            _decreaseEventsFilter.GetEntity(i).Del<HungerDecreaseEvent>();
        }
    }
}