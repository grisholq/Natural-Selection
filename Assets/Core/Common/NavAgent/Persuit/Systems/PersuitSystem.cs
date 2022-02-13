using UnityEngine;
using Leopotam.Ecs;

public class PersuitSystem : IEcsRunSystem
{
    private readonly EcsFilter<NavAgentComponent, PersuitState> _persuiersFilter;

    public void Run()
    {
        foreach (var i in _persuiersFilter)
        {
            var navAgentComponent = _persuiersFilter.Get1(i);
            var persuitState = _persuiersFilter.Get2(i);

            navAgentComponent.NavAgent.destination = persuitState.Target.position;
        }
    }
}