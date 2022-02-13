using Leopotam.Ecs;

public class FoodSearchToPersuitStateSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, FoodSearchState, FoodFoundEvent> _creaturesFoodFilter;

    public void Run()
    {
        foreach (var i in _creaturesFoodFilter)
        {
            var foodEvent = _creaturesFoodFilter.Get3(i);
        
            _creaturesFoodFilter.GetEntity(i).Del<FoodSearchState>();

            ref var persuitState = ref _creaturesFoodFilter.GetEntity(i).Get<FoodPersuitState>();
            persuitState.FoodTransform = foodEvent.FoodTransform; 
        }
    }
}