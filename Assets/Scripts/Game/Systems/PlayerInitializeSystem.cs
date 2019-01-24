using Entitas;
using UniRx;
using UnityEngine;

namespace Game.Systems
{
	public class PlayerInitializeSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public PlayerInitializeSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			Debug.Log("[InitializeSystem] Initialize");
			var entity = _contexts.game.CreateEntity();
			entity.AddPosition(Vector3.zero);
			entity.isPlayer = true;
		}
	}
}