using Entitas;
using Prototype.Scripts;
using UnityEngine;

namespace Game.Systems
{
    public class InitializeSystem : IPrioritySystem, IInitializeSystem
    {
        public int Priority { get; }
        private readonly GameContext _gameContext;

        public InitializeSystem(int priority, GameContext gameContext)
        {
            Priority = priority;
            _gameContext = gameContext;
        }

        public void Initialize()
        {
            Debug.Log("[InitializeSystem] Initialize");
            var position = Vector3.zero;
            var rotation = Quaternion.identity;
            EntitiesFactory.CreatePlayer(_gameContext, position, rotation);
        }
    }
}