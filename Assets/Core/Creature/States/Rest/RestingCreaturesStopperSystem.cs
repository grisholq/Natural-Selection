using Leopotam.Ecs;

public class RestingCreaturesStopperSystem : IEcsRunSystem
{
    private readonly EcsFilter<CreatureTag, NavAgentComponent, RestState> _restingCreatures;

    public void Run()
    {
        foreach (var i in _restingCreatures)
        {
            var navAgentComponent = _restingCreatures.Get2(i);

            if(navAgentComponent.NavAgent.isStopped == false)
            {
                _restingCreatures.GetEntity(i).Get<NavAgentStopEvent>();
            }
        }
    }
}