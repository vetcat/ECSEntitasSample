using Entitas;
using UnityEngine;

namespace Game.Systems
{
	public class PlayerMoveSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _group;
		
		public PlayerMoveSystem(GameContext context)
		{
			_group = context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Player));
		}		

		public void Execute()
		{			
			Debug.Log("[MoveSystem] Execute, entity count = " + _group.count);
			Update(Time.deltaTime);
		}

		public void Update(float deltaTime)
		{
			Debug.Log("[MoveSystem] Update, entity count = " + _group.count);
			
			foreach (var entity in _group)
			{
				//Debug.Log("[MoveSystem] Value = " + entity.movement.Value + "; deltaTime = " + deltaTime);
				var pos = entity.position.Value + Vector3.forward * deltaTime;				
				entity.ReplacePosition(pos);
			}
		}
	}
}