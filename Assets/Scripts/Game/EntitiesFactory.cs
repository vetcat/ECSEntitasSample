using Entitas;
using UnityEngine;

namespace Game
{
	public static class EntitiesFactory
	{
		public static Entity CreatePlayer(Contexts contexts, Vector3 position)
		{
			var entity = contexts.game.CreateEntity();
			entity.AddPosition(position);
			entity.AddSpeed(contexts.game.gameSettings.value.PlayerSpeed);
			entity.isPlayer = true;
			
			return entity; 
		}
	}
}