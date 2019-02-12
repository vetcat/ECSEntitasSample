using Entitas;
using UnityEngine;

namespace Game
{
	public static class EntitiesFactory
	{
		public static Entity CreatePlayer(GameContext context, Vector3 position, Quaternion forward)
		{
			var entity = context.CreateEntity();
			entity.AddRotation(forward);
			entity.AddPosition(position);
			entity.AddSpeed(context.gameSettings.value.PlayerMoveSpeed);
			entity.AddSpeedRotation(context.gameSettings.value.PlayerRotationSpeed);
			entity.AddShooting(0f, false);
			entity.isPlayer = true;
			
			return entity; 
		}

		public static Entity CreateShot(GameContext contexts, Vector3 position, Quaternion rotation)
		{			
			var entity = contexts.CreateEntity();
			entity.AddPosition(position);
			entity.AddRotation(rotation);
			entity.AddElapsedTime(0f);
			entity.isShot = true;
			
			return entity;
		}
	}
}