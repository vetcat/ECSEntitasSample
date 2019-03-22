using Entitas;
using UnityEngine;

namespace Game.Systems
{
    public class InitializeSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public InitializeSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            Debug.Log("[InitializeSystem] Initialize");
            var position = Vector3.zero;
            var rotation = Quaternion.identity;
            EntitiesFactory.CreatePlayer(_contexts.game, position, rotation);
        }
    }
}