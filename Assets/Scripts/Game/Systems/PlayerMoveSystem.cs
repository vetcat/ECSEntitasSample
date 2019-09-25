using Entitas;
using Prototype.Scripts;
using UnityEngine;

namespace Game.Systems
{
    public class PlayerMoveSystem : IExecuteSystem, IPrioritySystem
    {
        public int Priority { get; }
        private readonly IGroup<GameEntity> _group;
        private readonly InputContext _inputContext;

        public PlayerMoveSystem(int priority, GameContext gameContext, InputContext inputContext)
        {
            Priority = priority;
            _inputContext = inputContext;
            _group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerView, GameMatcher.Position,
                GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (var entity in _group)
            {
                var direction = entity.rotation.Value * Vector3.forward * _inputContext.inputState.Vertical;
                var nextPosition = entity.playerView.Value.SimpleMove(direction * entity.speed.Value);
                entity.ReplacePosition(nextPosition);
            }
        }
    }
}