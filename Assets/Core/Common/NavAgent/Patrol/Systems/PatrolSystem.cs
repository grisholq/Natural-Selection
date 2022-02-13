using UnityEngine;
using UnityEngine.AI;
using Leopotam.Ecs;

public class PatrolSystem : IEcsRunSystem
{
    private readonly EcsFilter<TransformComponent, NavAgentComponent, PatrolComponent, PatrolState> _parolersFilter;

    public void Run()
    {
        foreach (var i in _parolersFilter)
        {
            Transform transform = _parolersFilter.Get1(i).Transform;
            NavMeshAgent navAgent = _parolersFilter.Get2(i).NavAgent;
            float patrolStep = _parolersFilter.Get3(i).PatrolStep;

            if(navAgent.isStopped)
            {         
                ref var destinationEvent = ref _parolersFilter.GetEntity(i).Get<NavAgentDestinationEvent>();
                destinationEvent.Destination = GetPatrolPointOnNavMesh(transform.position, patrolStep);          
            }
        }      
    }

    private Vector3 GetPatrolPointOnNavMesh(Vector3 start, float radius)
    {
        NavMesh.SamplePosition(start, out NavMeshHit hit, radius, int.MaxValue);
        return hit.position;
    }
}