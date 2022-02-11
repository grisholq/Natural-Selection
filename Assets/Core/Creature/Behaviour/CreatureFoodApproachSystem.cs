using Leopotam.Ecs;

public class CreatureFoodApproachSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, NavAgentComponent, FoodFoundEvent> _foodFoundFilter;

    public void Run()
    {
        foreach (var i in _foodFoundFilter)
        {
            var foodEvent = _foodFoundFilter.Get3(i);
            ref var destinationEvent = ref _foodFoundFilter.GetEntity(i).Get<NavAgentDestinationEvent>();
            destinationEvent.Destination = foodEvent.FoodTransform.position; 
        }     
    }
}