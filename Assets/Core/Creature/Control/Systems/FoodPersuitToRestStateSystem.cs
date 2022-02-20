using UnityEngine;
using Leopotam.Ecs;

public class FoodPersuitToRestStateSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, EnergyComponent, FoodPersuitState> _foodPersuitersFilter;

    public void Run()
    {
        foreach (var i in _foodPersuitersFilter)
        {
            var energyComponent = _foodPersuitersFilter.Get2(i);

            if (energyComponent.Energy > energyComponent.HungerThreshold)
            {
                _foodPersuitersFilter.GetEntity(i).Del<FoodPersuitState>();
                _foodPersuitersFilter.GetEntity(i).Get<RestState>();

                Debug.Log("From persuit to rest");
            }
        }
    }
}