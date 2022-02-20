using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class FoodSourceTriggerMono : EntityTriggerMono
{
    protected override void HandleTriggerEnter(EntityReference reference)
    {
        AddEnergyToCreature(reference.Entity);
        SendDeathEventToFoodSource();
    }

    private void AddEnergyToCreature(EcsEntity entity)
    {
        if (entity.Has<CreatureTag>())
        {
            float energy = Entity.Get<FoodSourceComponent>().EnergyGain;

            EcsEntity energyEvent = WorldHandler.GetWorld().NewEntity();

            ref var entityComponent = ref energyEvent.Get<EntityComponent>();
            ref var addEvent = ref energyEvent.Get<EnergyAddEvent>();

            entityComponent.Entity = entity;
            addEvent.EnergyAdd = energy;
        }
    }

    private void SendDeathEventToFoodSource()
    {
        Entity.Get<DestroyEvent>();
    }
}
