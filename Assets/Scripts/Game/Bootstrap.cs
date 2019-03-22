using Game.Settings;
using UnityEngine;
using Game.Systems;
using Input;

namespace Game
{
    public class Bootstrap : MonoBehaviour
    {
        private Entitas.Systems _systems;
        private Contexts _context;
        private PlayerMoveSystem _playerMoveSystem;

        public void Start()
        {
            var settings = Resources.Load("GameSettings") as GameSettings;

            _context = new Contexts();
            _context.game.SetGameSettings(settings);
            _context.game.SetDeltaTime(0f);
            _context.input.SetInputState(0f, 0f, false, false, false);

            _systems = new Feature("Game").Add(new InitializeSystem(_context))
                //reactive system
                .Add(new AddPlayerViewReactiveSystem(_context)).Add(new AddShotViewReactiveSystem(_context))
                //execute system
                .Add(new DeltaTimeUpdateSystem(_context.game)).Add(new InputStateStandartSystem(_context.input))
                .Add(new PlayerMoveSystem(_context.game, _context.input))
                .Add(new PlayerRotationSystem(_context.game, _context.input))
                .Add(new PlayerShootingSystem(_context.game, _context.input)).Add(new ShotsMoveSystem(_context.game))
                .Add(new GameEventSystems(_context)).Add(new DestroyReactiveSystem(_context.game));

            _systems.Initialize();
        }

        public void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}