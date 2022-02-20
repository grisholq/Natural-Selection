using Leopotam.Ecs;

public class FoodSearchPatrolStartSystem : IEcsRunSystem
{
    private readonly EcsFilter<NavAgentComponent, FoodSearchState>.Exclude<PatrolState> _foodSearchersFilter;

    public void Run()
    {
        foreach (var i in _foodSearchersFilter)
        {
            _foodSearchersFilter.GetEntity(i).Get<PatrolState>();
        }
    }
}