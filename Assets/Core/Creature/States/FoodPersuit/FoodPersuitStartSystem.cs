using UnityEngine;
using Leopotam.Ecs;

public class FoodPersuitStartSystem : IEcsRunSystem
{
    private readonly EcsFilter<NavAgentComponent, FoodPersuitState>.Exclude<PersuitState> _foodPersuitersFilter;

    public void Run()
    {
        foreach (var i in _foodPersuitersFilter)
        {
            var foodPersuitState = _foodPersuitersFilter.Get2(i);

            ref var persuitState = ref _foodPersuitersFilter.GetEntity(i).Get<PersuitState>();
            persuitState.Target = foodPersuitState.FoodTransform;
        }
    }
}