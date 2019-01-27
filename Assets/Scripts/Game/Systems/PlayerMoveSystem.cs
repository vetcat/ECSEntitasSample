using Entitas;
using UnityEngine;

namespace Game.Systems
{
	public class PlayerMoveSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _group;
		private readonly GameContext _context;

		public PlayerMoveSystem(GameContext context)
		{
			_context = context;
			_group = context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Player, GameMatcher.View,
				GameMatcher.Speed));
		}		

		public void Execute()
		{			
			foreach (var entity in _group)
			{
				var speed = _context.gameSettings.value.PlayerSpeed;
				var pos = entity.position.Value + Vector3.forward * _context.deltaTime.Value * speed;				
				entity.ReplacePosition(pos);
			}
		}
	}
}