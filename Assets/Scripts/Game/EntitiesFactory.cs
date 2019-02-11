using Entitas;
using UnityEngine;

namespace Game
{
	public static class EntitiesFactory
	{
		public static Entity CreatePlayer(GameContext contexts, Vector3 position, Quaternion forward)
		{
			var entity = contexts.CreateEntity();
			entity.AddRotation(forward);
			entity.AddPosition(position);
			entity.AddShooting(0f, false);
			entity.isPlayer = true;
			
			return entity; 
		}

		public static Entity CreateShot(GameContext contexts, Vector3 position, Quaternion rotation)
		{			
			var entity = contexts.CreateEntity();
			entity.AddPosition(position);
			entity.AddRotation(rotation);
			entity.isShot = true;
			
			return entity;
		}
	}
}