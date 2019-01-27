using Entitas;
using UniRx;
using UnityEngine;

namespace Game.Systems
{
	public class InitializeSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public InitializeSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			Debug.Log("[InitializeSystem] Initialize");						
			EntitiesFactory.CreatePlayer(_contexts, Vector3.zero);
		}
	}
}