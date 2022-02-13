using Leopotam.Ecs;

public class NavAgentSetDestinationSystem : IEcsRunSystem
{
    private readonly EcsFilter<NavAgentComponent, NavAgentDestinationEvent> _destinationEventsFilter = null;

    public void Run()
    {
        foreach (var i in _destinationEventsFilter)
        {
            var agent = _destinationEventsFilter.Get1(i);
            var destinationEvent = _destinationEventsFilter.Get2(i);

            agent.NavAgent.SetDestination(destinationEvent.Destination);

            _destinationEventsFilter.GetEntity(i).Del<NavAgentDestinationEvent>();
        }
    }
}