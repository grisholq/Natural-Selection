using UnityEngine;
using Leopotam.Ecs;

public class FoodSearchPatrolStopSystem : IEcsRunSystem
{
    private readonly EcsFilter<NavAgentComponent, PatrolState>.Exclude<FoodSearchState> _wrongPatrolersSystem;

    public void Run()
    {
        foreach (var i in _wrongPatrolersSystem)
        {
            _wrongPatrolersSystem.GetEntity(i).Del<PatrolState>();
        }
    }
}