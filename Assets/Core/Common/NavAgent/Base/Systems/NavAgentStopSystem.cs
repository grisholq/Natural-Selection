using UnityEngine;
using Leopotam.Ecs;

public class NavAgentStopSystem : IEcsRunSystem
{
    private readonly EcsFilter<NavAgentComponent, NavAgentStopEvent> _stopEventsFilter;

    public void Run()
    {
        foreach (var i in _stopEventsFilter)
        {
            var agent = _stopEventsFilter.Get1(i);

            agent.NavAgent.isStopped = true;

            _stopEventsFilter.GetEntity(i).Del<NavAgentStopEvent>();
        }
    }
}