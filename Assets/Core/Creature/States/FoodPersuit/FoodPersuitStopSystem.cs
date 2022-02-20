using UnityEngine;
using Leopotam.Ecs;

public class FoodPersuitStopSystem : IEcsRunSystem
{
    private readonly EcsFilter<NavAgentComponent, PersuitState>.Exclude<FoodPersuitState> _wrongPersuitersFilter;

    public void Run()
    {
        foreach (var i in _wrongPersuitersFilter)
        {
            _wrongPersuitersFilter.GetEntity(i).Del<PersuitState>();
        }
    }
}