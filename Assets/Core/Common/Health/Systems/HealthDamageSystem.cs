using UnityEngine;
using Leopotam.Ecs;

public class HealthDamageSystem : IEcsRunSystem
{
    private readonly EcsFilter<HealthComponent, HealthDamageEvent> _damageFilter;

    public void Run()
    {
        foreach (var i in _damageFilter)
        {
            ref var healthComponent = ref _damageFilter.Get1(i);
            var damageEvent = _damageFilter.Get2(i);

            healthComponent.Value -= damageEvent.Value;

            _damageFilter.GetEntity(i).Del<HealthDamageEvent>();
        }
    }
}