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
            float sampleRadius = _parolersFilter.Get2(i).SampleRadius;
            float partolRadius = _parolersFilter.Get3(i).PatrolRadius;

            if(navAgent.IsMoving() == false)
            {              
                ref var destinationEvent = ref _parolersFilter.GetEntity(i).Get<NavAgentDestinationEvent>();
                destinationEvent.Destination = GetPatrolPointOnNavMesh(transform.position, partolRadius, sampleRadius);          
            }
        }      
    }

    private Vector3 GetPatrolPointOnNavMesh(Vector3 start, float randomRadius, float sampleRadius)
    {
        Vector3 position = start;
        Vector2 randomization = Random.insideUnitCircle * randomRadius;
        position.x += randomization.x;
        position.z += randomization.y;

        bool found = NavMesh.SamplePosition(position, out NavMeshHit hit, sampleRadius, int.MaxValue);
        return hit.position;
    }
}