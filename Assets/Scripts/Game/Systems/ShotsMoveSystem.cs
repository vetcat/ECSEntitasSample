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
            _group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Shot, GameMatcher.ShotView));
        }

        public void Execute()
        {
            var deltaTime = _gameContext.deltaTime.Value;

            foreach (var entity in _group)
            {
                var shotView = entity.shotView.Value;
                var view = entity.view.Value;
                shotView.Elapsed += deltaTime;                        

                if (shotView.Elapsed >= shotView.LifeTime)
                {
                    //_signalBus.Fire(new SignalShotDestroy(view));
                    //Debug.Log("need destroy");
                }
                else
                {
                    var velocity = view.GetForward() * shotView.Speed * deltaTime;                    
                    var nextPosition = view.GetPosition() + velocity;
                    var distance = Vector3.Distance(view.GetPosition(), nextPosition);                                                                                
                                
                    if (Physics.Raycast(view.GetPosition(), view.GetForward(), out _hit, distance))
                    {                                        
//                        _signalBus.Fire(new SignalShotFXSpawn(_hit.point, _hit.normal));
//                        _signalBus.Fire(new SignalShotDestroy(view));
                        //Debug.Log("need destroy and create FX");
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