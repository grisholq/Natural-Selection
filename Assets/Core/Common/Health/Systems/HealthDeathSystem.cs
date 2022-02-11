using Leopotam.Ecs;

public class HealthDeathSystem : IEcsRunSystem
{
    private readonly EcsFilter<HealthComponent> _healthFilter;

    public void Run()
    {
        foreach (var i in _healthFilter)
        {
            var health = _healthFilter.Get1(i);

            if (health.Value <= 0)
            {
                _healthFilter.GetEntity(i).Get<DeathEvent>();
            }
        }
    }
}