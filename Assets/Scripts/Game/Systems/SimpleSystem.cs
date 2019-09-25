using Entitas;
using Prototype.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Systems
{
    public class SimpleSystem : IExecuteSystem, IPrioritySystem
    {
        public int Priority { get; }

        private readonly SignalBus _signalBus;

        public SimpleSystem(int priority, GameContext context, SignalBus signalBus)
        {
            Priority = priority;
            _signalBus = signalBus;
            Debug.Log("[SimpleSystem] create contextInfo " + context.contextInfo);
        }

        public void Execute()
        {
            Debug.Log("[SimpleSystem] Execute");
        }
    }
}