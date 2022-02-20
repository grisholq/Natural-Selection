using UnityEngine.AI;

public static class NavMeshAgentExtentions
{
    public static bool IsMoving(this NavMeshAgent agent)
    {
        return agent.velocity.magnitude != 0;
    }
}
