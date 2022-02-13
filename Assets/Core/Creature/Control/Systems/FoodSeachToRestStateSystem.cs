using Leopotam.Ecs;

public class FoodSeachToRestStateSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, EnergyComponent, FoodSearchState> _foodSearchersFilter;

    public void Run()
    {
        foreach (var i in _foodSearchersFilter)
        {
            var energyComponent = _foodSearchersFilter.Get2(i);

            if(energyComponent.Energy >= CreatureSettings.CreatureSearchEnergyTreshold)
            {
                _foodSearchersFilter.GetEntity(i).Del<FoodSearchState>();
                _foodSearchersFilter.GetEntity(i).Get<RestState>();
            }
        }
    }
}