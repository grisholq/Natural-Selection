using Leopotam.Ecs;

public class FoodSearchToPersuitStateSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, FoodSearchState, FoodFoundEvent> _creaturesFoodFilter;

    public void Run()
    {
        
    }
}