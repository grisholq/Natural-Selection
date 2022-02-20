using UnityEngine;
using Leopotam.Ecs;

public class NavAgentDestinationBlockSystem : IEcsRunSystem
{
    private readonly EcsFilter<NavAgentDestinationBlock> _blocksFilter;
    public void Run()
    {
        foreach (var i in _blocksFilter)
        {
            ref var block = ref _blocksFilter.Get1(i);

            block.Duration -= Time.deltaTime;
            
            if(block.Duration <= 0)
            {
                _blocksFilter.GetEntity(i).Del<NavAgentDestinationBlock>();
            }
        }
    }
}