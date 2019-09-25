using Entitas;
using Prototype.Scripts;
using UnityEngine;

namespace Game.Systems
{
    public class ShotsMoveSystem : IExecuteSystem, IPrioritySystem
    {
        public int Priority { get; }
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _group;
        private RaycastHit _hit;

        public ShotsMoveSystem(int priority, GameContext gameContext)
        {
            Priority = priority;
            _gameContext = gameContext;
            _group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Shot, GameMatcher.Position,
                GameMatcher.Rotation, GameMatcher.Speed, GameMatcher.LifeTime));
        }

        public void Execute()
        {
            var deltaTime = _gameContext.deltaTime.Value;

            foreach (var entity in _group)
            {
                entity.elapsedTime.Value += deltaTime;

                if (entity.elapsedTime.Value >= entity.lifeTime.Value)
                {
                    entity.isDestroy = true;
                }
                else
                {
                    var forward = entity.rotation.Value * Vector3.forward;
                    var velocity = forward * entity.speed.Value * deltaTime;
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