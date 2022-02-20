using UnityEngine;
using Leopotam.Ecs;

public class BeingEnergyConsumptionSystem : IEcsRunSystem
{
    private readonly EcsFilter<EnergyComponent, BeingEnergyConsumptionComponent> _beingConsumptionFilter;

    public void Run()
    {
        foreach (var i in _beingConsumptionFilter)
        {
            ref var energyComponent = ref _beingConsumptionFilter.Get1(i);
            var consumpsionComponent = _beingConsumptionFilter.Get2(i);

            energyComponent.Energy -= consumpsionComponent.Energy * Time.deltaTime;
        }
    }
}