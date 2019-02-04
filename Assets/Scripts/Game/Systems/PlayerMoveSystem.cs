using Entitas;
using Game.Views;
using UnityEngine;

namespace Game.Systems
{
	public class PlayerMoveSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _group;
		private readonly GameContext _gameContext;
		private readonly InputContext _inputContext;

		public PlayerMoveSystem(GameContext gameContext, InputContext inputContext)
		{
			_inputContext = inputContext;
			_gameContext = gameContext;
			_group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.PlayerView));
		}		

		public void Execute()
		{			
			foreach (var entity in _group)
			{				
				var direction = entity.playerView.Value.TransformDirection(new Vector3(0f, 0f, _inputContext.inputState.Vertical));				
				var speed = _gameContext.gameSettings.value.PlayerMoveSpeed;
				entity.playerView.Value.SimpleMove(direction * speed);
				entity.position.Value = entity.playerView.Value.GetPosition();
				//var pos = entity.position.Value + Vector3.forward * _gameContext.deltaTime.Value * speed;				
				//entity.ReplacePosition(pos);
			}
		}
	}
}