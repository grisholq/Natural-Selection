using DCFA;
using UnityEngine.AI;

[EcsLinkComponent]
public struct NavAgentComponent
{
    public NavMeshAgent NavAgent;
    public float SampleRadius;
}