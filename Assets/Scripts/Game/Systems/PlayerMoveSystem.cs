using Entitas;
using UnityEngine;

namespace Game.Systems
{
	public class PlayerMoveSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _group;
		private GameContext _context;

		public PlayerMoveSystem(GameContext context)
		{
			_context = context;
			_group = context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Player));
		}		

		public void Execute()
		{			
			//Debug.Log("[MoveSystem] Execute, entity count = " + _group.count);
			//Debug.Log("[MoveSystem] Execute _context.deltaTime = " + _context.deltaTime.Value);
			foreach (var entity in _group)
			{
				//Debug.Log("[MoveSystem] Value = " + entity.movement.Value + "; deltaTime = " + deltaTime);
				var pos = entity.position.Value + Vector3.forward * _context.deltaTime.Value;				
				entity.ReplacePosition(pos);
			}
		}
	}
}