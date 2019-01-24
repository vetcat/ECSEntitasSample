using UnityEngine;
using Zenject;
using Game.Systems;

namespace Game
{
	public class GameInstaller : MonoInstaller
	{
		public Globals Globals;
		
		private Entitas.Systems _systems;
		private Contexts _context;
		private PlayerMoveSystem _playerMoveSystem;		

		public override void InstallBindings()
		{
			Debug.Log("[GameInstaller] InstallBindings");
		}

		public override void Start()
		{					
			_context = new Contexts();
			_context.game.SetGlobals(Globals);
			
			_systems = new Feature("Game").
				Add(new PlayerInitializeSystem(_context)).
				Add(new AddPlayerViewSystem(_context));
			
			_systems.Initialize();
			
			//add
			//var entity = _systems.CreateEntity();
			//entity.AddMovement(10, new ReactiveProperty<float>(20));
		}

		public override void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}
	}
}