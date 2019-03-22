using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game.Components
{
    [Game, Event(true)]
    public class PositionComponent : IComponent
    {
        public Vector3 Value;
    }
}