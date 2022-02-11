using UnityEngine;
using Leopotam.Ecs;

public class HealthRegenerationSystem : IEcsRunSystem
{
    private readonly EcsFilter<HealthComponent, HealthRegeneration> _regenerationFilter;

    public void Run()
    {
        foreach (var i in _regenerationFilter)
        {
            ref var healthComponent = ref _regenerationFilter.Get1(i);
            ref var regenerationComponent = ref _regenerationFilter.Get2(i);

            float regeneration;

            if(regenerationComponent.Speed < regenerationComponent.Value)
            {
                healthComponent.Value += regenerationComponent.Speed;
                regenerationComponent.Value -= regenerationComponent.Speed;
            }
            else
            {
                healthComponent.Value += regenerationComponent.Value;
                regenerationComponent.Value = 0;
            }

            if (regenerationComponent.Value <= 0)
            {
                _regenerationFilter.GetEntity(i).Del<HealthRegeneration>();
            }
        }
    }
}