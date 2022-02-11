using UnityEngine;
using Leopotam.Ecs;

public class EntityReference : MonoBehaviour
{
    public EcsEntity Entity { get; set; }
    public bool Inizialized { get; set; } = false;
}