using Leopotam.Ecs;

public class HungerIncreaseSystem : IEcsRunSystem
{
    private readonly EcsFilter<HungerComponent, HungerIncreaseEvent> _increaseEventFilter;

    public void Run()
    {
        foreach (var i in _increaseEventFilter)
        {
            ref var hungerComponent = ref _increaseEventFilter.Get1(i);
            var increaseEvent = _increaseEventFilter.Get2(i);

            hungerComponent.Hunger += increaseEvent.HungerIncrease;

            _increaseEventFilter.GetEntity(i).Del<HungerIncreaseEvent>();
        }
    }
}