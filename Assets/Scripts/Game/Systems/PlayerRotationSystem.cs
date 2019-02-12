using Entitas;
using UnityEngine;

namespace Game.Systems
{
    public class PlayerRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly GameContext _gameContext;
        private InputContext _inputContext;

        public PlayerRotationSystem(GameContext gameContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _gameContext = gameContext;
            _group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerView, GameMatcher.Rotation, GameMatcher.SpeedRotation));
        }		

        public void Execute()
        {			
            foreach (var entity in _group)
            {                
                var deltaTime = _gameContext.deltaTime.Value;
                var rotation = _inputContext.inputState.Horizontal * entity.speedRotation.Value * deltaTime;                
                var nextRotation = entity.rotation.Value * Quaternion.Euler(new Vector3(0f, rotation, 0f));
                entity.ReplaceRotation(nextRotation);                
            }
        }
    }
}