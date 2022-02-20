using Leopotam.Ecs;

public class RestStateStopperSystem : IEcsRunSystem
{
    private readonly EcsFilter<NavAgentComponent, RestState> _restingAgents;

    public void Run()
    {
        foreach (var i in _restingAgents)
        {
            var agentComponent = _restingAgents.Get1(i);

            if(agentComponent.NavAgent.IsMoving())
            {
                _restingAgents.GetEntity(i).Get<NavAgentStopEvent>();
            }
        }
    }
}