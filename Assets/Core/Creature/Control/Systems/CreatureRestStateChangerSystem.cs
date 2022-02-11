using Leopotam.Ecs;

public class CreatureRestStateChangerSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, EnergyComponent> _creaturesFilter;

    public void Run()
    {
        foreach (var i in _creaturesFilter)
        {
            var energyComponent = _creaturesFilter.Get2(i);
            float energyTreshold = CreatureSettings.CreatureSearchEnergyTreshold;

            if (energyComponent.Energy <= energyTreshold)
            {
                _creaturesFilter.GetEntity(i).Del<RestState>();
            }
            else
            {
                _creaturesFilter.GetEntity(i).Get<RestState>();
            }
        }
    }
}
