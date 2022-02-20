using UnityEngine;
using Leopotam.Ecs;

public class RestToFoodSearchStateSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, EnergyComponent, RestState> _restingCreaturesFilter;

    public void Run()
    {
        foreach (var i in _restingCreaturesFilter)
        {
            var energyComponent = _restingCreaturesFilter.Get2(i);
            

            if(energyComponent.Energy < energyComponent.HungerThreshold)
            {
                _restingCreaturesFilter.GetEntity(i).Get<FoodSearchState>();
                _restingCreaturesFilter.GetEntity(i).Del<RestState>();
                Debug.Log("From rest to search");
            }            
        }
    }
}