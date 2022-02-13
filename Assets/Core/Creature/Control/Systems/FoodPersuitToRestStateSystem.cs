using Leopotam.Ecs;

public class FoodPersuitToRestStateSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, EnergyComponent, FoodPersuitState> _foodPersuitersFilter;

    public void Run()
    {
        foreach (var i in _foodPersuitersFilter)
        {
            var energyComponent = _foodPersuitersFilter.Get2(i);

            if (energyComponent.Energy >= CreatureSettings.CreatureSearchEnergyTreshold)
            {
                EcsEntity entity = _foodPersuitersFilter.GetEntity(i);
                entity.Del<FoodPersuitState>();
                entity.Get<RestState>();
            }
        }
    }
}