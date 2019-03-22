using Entitas;
using UnityEngine;

namespace Game.Systems
{
    public class PlayerMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly InputContext _inputContext;

        public PlayerMoveSystem(GameContext gameContext, InputContext inputContext)
        {
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