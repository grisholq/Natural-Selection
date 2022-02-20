using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;

public class FoodSearchSystem : IEcsRunSystem
{
    private readonly EcsFilter<TransformComponent, FeelComponent, FoodSearchState> _searchingCreaturesFilter;

    public void Run()
    {
        foreach (var i in _searchingCreaturesFilter)
        {
            

            var transformComponent = _searchingCreaturesFilter.Get1(i);
            var fillComponent = _searchingCreaturesFilter.Get2(i);

            List<EcsEntity> entities = GetEntitiesInRange(transformComponent.Transform.position, fillComponent.Range);

            if (TryGetFoodSourceFromEntities(entities, out EcsEntity foodSource))
            {
                
                Transform foodTransform = foodSource.Get<TransformComponent>().Transform;

                ref var foodEvent = ref _searchingCreaturesFilter.GetEntity(i).Get<FoodFoundEvent>();
                foodEvent.FoodTransform = foodTransform;
            }
        }
    }

    private bool TryGetFoodSourceFromEntities(List<EcsEntity> entities, out EcsEntity foodEntity)
    {
        foreach (var entity in entities)
        {
            
            if (entity.Has<TransformComponent>() && entity.Has<FoodTag>())
            {
                foodEntity = entity;
                return true;
            }
        }

        foodEntity = new EcsEntity();
        return false;
    }

    private List<EcsEntity> GetEntitiesInRange(Vector3 start, float range)
    {
        Collider[] colliders = GetCollidersInRange(start, range);

        List<EcsEntity> entities = new List<EcsEntity>();

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out EntityReference reference))
            {
                entities.Add(reference.Entity);
            }
        }

        return entities;
    }

    private Collider[] GetCollidersInRange(Vector3 start, float range)
    {
        return Physics.OverlapSphere(start, range);
    }
}