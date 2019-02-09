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
                        //var firePoint = model.CurrentWeaponView.GetFirePoint();
                        var firePoint = Vector3.zero;
                        //Fire(model.CurrentWeaponView.FireRate, firePoint.position, firePoint.forward);
                        EntitiesFactory.CreateShot(_gameContext, firePoint, firePoint);
                        Debug.Log("CreateShot");
                        entity.ReplaceShooting(0f, false);                        
                    }

                    entity.shooting.DurationTime += deltaTime;
                    if (entity.shooting.DurationTime >= fireRate)
                    {
                        //var firePoint = model.CurrentWeaponView.GetFirePoint();
                        var firePoint = Vector3.zero;
                        EntitiesFactory.CreateShot(_gameContext, firePoint, firePoint);
                        Debug.Log("CreateShot");
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