using Entitas;
using Game;
using Game.Systems;
using Input;
using NUnit.Framework;
using UnityEngine;

public class PlayerRotationSystemTest
{
	private Contexts _context;	
	private PlayerRotationSystem _playerRotationSystem;
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
		_context.input.SetInputState(0f, 0f, false, false, false);
							
		_playerRotationSystem = new PlayerRotationSystem(_context.game, _context.input);
		_gameEventSystems = new GameEventSystems(_context);
		_addPlayerViewReactiveSystem = new AddPlayerViewReactiveSystem(_context);
		
		_systems = new Feature("Game")
			.Add(_addPlayerViewReactiveSystem)			
			.Add(_playerRotationSystem)
			.Add(_gameEventSystems);	
		
		_player = (GameEntity)EntitiesFactory.CreatePlayer(_context, Vector3.zero, Vector3.zero);
		_systems.Execute();
	}

	[Test]
	public void Player_StartRotation_EqualZero()
	{
		Assert.AreEqual(Vector3.zero, _player.rotation.Value);
	}

	[Test]
	public void Player_HorizontalInput_EqualCalculateRotation()
	{
		_player.rotation.Value = Vector3.zero;
		var deltaTime = 1f;
		_context.game.deltaTime.Value = deltaTime;
		var horizontalInput = 1f;
		_context.input.ReplaceInputState(horizontalInput, 0f, false, false, false);
		var speed = _context.game.gameSettings.value.PlayerRotationSpeed;
		var calculateRotation = _context.input.inputState.Horizontal * speed * deltaTime; 
		
		_systems.Execute();
		
		Assert.AreEqual(new Vector3(0f, calculateRotation , 0f), _player.rotation.Value);
	}
}
