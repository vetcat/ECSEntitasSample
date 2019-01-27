using UnityEngine;
using Zenject;
using Game.Systems;

namespace Game
{
	public class GameInstaller : MonoInstaller
	{				
		private Entitas.Systems _systems;
		private Contexts _context;
		private PlayerMoveSystem _playerMoveSystem;		

		public override void InstallBindings()
		{
			Debug.Log("[GameInstaller] InstallBindings");
		}

		public override void Start()
		{
			var settings = Resources.Load("GameSettings") as GameSettings;
			
			_context = new Contexts();
			_context.game.SetGameSettings(settings);
			_context.game.SetDeltaTime(0f);
			
			_systems = new Feature("Game").
				Add(new InitializeSystem(_context)).
				Add(new DeltaTimeUpdateSystem(_context.game)).
				Add(new AddPlayerViewReactiveSystem(_context)).				
				Add(new PlayerMoveSystem(_context.game)).
				Add(new GameEventSystems(_context));
			
			_systems.Initialize();
		}

		public override void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}
	}
}