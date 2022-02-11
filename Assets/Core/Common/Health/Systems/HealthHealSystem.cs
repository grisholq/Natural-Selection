using UnityEngine;
using Leopotam.Ecs;

public class HealthHealSystem : IEcsRunSystem
{
    private readonly EcsFilter<HealthComponent, HealthHealEvent> _healFilter;

    public void Run()
    {
        foreach (var i in _healFilter)
        {
            ref var healthComponent = ref _healFilter.Get1(i);
            var healEvent = _healFilter.Get2(i);

            healthComponent.Value += healEvent.Value;

            _healFilter.GetEntity(i).Del<HealthHealEvent>();
        }
    }
}