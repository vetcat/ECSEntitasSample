using Entitas;
using UnityEngine;

namespace Game.Systems
{
    public class ShotsMoveSystem : IExecuteSystem
    {
        private GameContext _gameContext;
        private readonly IGroup<GameEntity> _group;
        private RaycastHit _hit;

        public ShotsMoveSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Shot, GameMatcher.ShotView, 
                GameMatcher.Position, GameMatcher.Rotation));
        }

        public void Execute()
        {
            var deltaTime = _gameContext.deltaTime.Value;

            foreach (var entity in _group)
            {
                var shotView = entity.shotView.Value;
                shotView.Elapsed += deltaTime;                        

                if (shotView.Elapsed >= shotView.LifeTime)
                {
                    entity.isDestroy = true;
                }
                else
                {
                    var forward = entity.rotation.Value * Vector3.forward;
                    var velocity =  forward * shotView.Speed * deltaTime;                 
                    var nextPosition = entity.position.Value + velocity;                                                                                                    
                    var distance = Vector3.Distance(entity.position.Value, nextPosition);
                    
                    if (Physics.Raycast(entity.position.Value, forward, out _hit, distance))
                    {                                        
//                        _signalBus.Fire(new SignalShotFXSpawn(_hit.point, _hit.normal));                      
                        //Debug.Log("need destroy and create FX");
                        entity.isDestroy = true;
                    }
                    else
                    {
                        entity.ReplacePosition(nextPosition);            
                    }
                }
            }
        }
    }
}