using Entitas;
using Game;
using Game.Systems;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor.Game
{
	public class PlayerMoveSystemTest
	{
		private Contexts _context; 						
		private PlayerMoveSystem _playerMoveSystem;
		private GameEventSystems _gameEventSystems;
		private AddPlayerViewReactiveSystem _addPlayerViewReactiveSystem;		
		private Systems _systems;
		private GameEntity _player;
	
		[SetUp]
		public void SetUp()
		{
			var settings = Resources.Load("GameSettings") as GameSettings;
			
			_context = new Contexts();
			_context.game.SetDeltaTime(0f);
			_context.game.SetGameSettings(settings);
						
			_playerMoveSystem = new PlayerMoveSystem(_context.game);
			_gameEventSystems = new GameEventSystems(_context);
			_addPlayerViewReactiveSystem = new AddPlayerViewReactiveSystem(_context);
			
			_systems = new Feature("Game")
				.Add(_addPlayerViewReactiveSystem)
				.Add(_playerMoveSystem)
				.Add(_gameEventSystems);	
			
			_player = (GameEntity)EntitiesFactory.CreatePlayer(_context, Vector3.zero);
			_systems.Execute();
		}

		[Test]
		public void Move_DeltaTime_Simple()
		{
			_player.ReplacePosition(Vector3.zero);
			float dt = 1f;
			_context.game.deltaTime.Value = dt;									
			
			var finalPosition = _player.position.Value + Vector3.forward * dt;
			_systems.Execute();

			Assert.AreEqual(_player.position.Value, finalPosition);
		}

		[Test]
		public void Equal_Position_to_RealPosition()
		{						
			var view = _player.view.Value;
			Assert.AreEqual(view.GetRealPosition(), _player.position.Value);			
		}
	}
}