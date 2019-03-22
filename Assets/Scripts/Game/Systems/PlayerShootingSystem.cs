using Entitas;

namespace Game.Systems
{
    public class PlayerShootingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;
        private GameContext _gameContext;
        private InputContext _inputContext;

        public PlayerShootingSystem(GameContext gameContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _gameContext = gameContext;
            _group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Shooting, GameMatcher.Player,
                GameMatcher.Position, GameMatcher.Rotation));
        }

        public void Execute()
        {
            var deltaTime = _gameContext.deltaTime.Value;
            var fireRate = 1f;

            foreach (var entity in _group)
            {
                if (_inputContext.inputState.IsFireProcess)
                {
                    if (entity.shooting.IsFirstTimeShot)
                    {
                        EntitiesFactory.CreateShot(_gameContext, entity.position.Value, entity.rotation.Value);
                        entity.ReplaceShooting(0f, false);
                    }

                    entity.shooting.DurationTime += deltaTime;
                    if (entity.shooting.DurationTime >= fireRate)
                    {
                        EntitiesFactory.CreateShot(_gameContext, entity.position.Value, entity.rotation.Value);
                        entity.shooting.DurationTime -= fireRate;
                    }
                }
                else
                {
                    if (entity.shooting.DurationTime < fireRate)
                        entity.shooting.DurationTime += deltaTime;

                    if (!entity.shooting.IsFirstTimeShot && entity.shooting.DurationTime > fireRate)
                        entity.shooting.IsFirstTimeShot = true;
                }
            }
        }
    }
}