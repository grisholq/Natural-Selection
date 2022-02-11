using Leopotam.Ecs;

public class FoodSearchToPersuitStateSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, FoodSearchState, FoodFoundEvent> _creaturesFoodFilter;

    public void Run()
    {
        foreach (var i in _creaturesFoodFilter)
        {
            var energyComponent = _creaturesFoodFilter.Get2(i);

            _creaturesFoodFilter.GetEntity(i).Get<FoodPersuitState>();
            _creaturesFoodFilter.GetEntity(i).Del<FoodSearchState>();
        }
    }
}