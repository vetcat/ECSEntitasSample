using Entitas;
using UnityEngine;

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
            _group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Shooting, GameMatcher.Player));
        }

        public void Execute()
        {
            var deltaTime = _gameContext.deltaTime.Value;
            float fireRate = 1f;
            
            foreach (var entity in _group)
            {
                if (_inputContext.inputState.IsFireProcess)
                {
                    if (entity.shooting.IsFirstTimeShot)
                    {
                        CreateShot(entity, _gameContext);
                        entity.ReplaceShooting(0f, false);                        
                    }

                    entity.shooting.DurationTime += deltaTime;
                    if (entity.shooting.DurationTime >= fireRate)
                    {
                        CreateShot(entity, _gameContext);
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

        private void CreateShot(GameEntity entity, GameContext gameContext)
        {
            var firePoint = entity.playerView.Value.GetPosition();
            var fireForward = entity.playerView.Value.GetRotation();            
            //EntitiesFactory.CreateShot(gameContext, firePoint, fireForward.eulerAngles);
            EntitiesFactory.CreateShot(gameContext, firePoint, Vector3.zero);
        }
    }
}