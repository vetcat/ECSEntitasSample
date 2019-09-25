using System.Collections.Generic;
using Entitas;
using Game.Views;
using Prototype.Scripts;
using UnityEngine;
using Views.Linkable;

namespace Game.Systems
{
    public class AddShotViewReactiveSystem : ReactiveSystem<GameEntity>, IPrioritySystem
    {
        public int Priority { get; }
        private readonly GameContext _gameContext;

        public AddShotViewReactiveSystem(int priority, GameContext gameContext) : base(gameContext)
        {
            Priority = priority;
            _gameContext = gameContext;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Shot));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isShot;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            //todo перевести на pool
            var prefab = _gameContext.gameSettings.value.ShotPrefab;

            foreach (var entity in entities)
            {
                var shot = GameObject.Instantiate(prefab);

                var link = shot.GetComponent<ILinkable>();
                link.Link(entity, _gameContext);

                var shotView = shot.GetComponent<IShotView>();
                var settings = shotView.GetSettings();

                entity.AddSpeed(settings.Speed);
                entity.AddLifeTime(settings.LifeTime);
                entity.AddDamage(settings.Damage);

                entity.ReplacePosition(entity.position.Value);
                entity.ReplaceRotation(entity.rotation.Value);
            }
        }
    }
}