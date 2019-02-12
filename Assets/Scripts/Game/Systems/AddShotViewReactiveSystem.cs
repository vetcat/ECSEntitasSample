using System.Collections.Generic;
using Entitas;
using Game.Views;
using UnityEngine;

namespace Game.Systems
{
    public class AddShotViewReactiveSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public AddShotViewReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
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
            var prefab = _contexts.game.gameSettings.value.ShotPrefab;            

            foreach (var entity in entities)
            {
                var shot = GameObject.Instantiate(prefab);
				
                var link = shot.GetComponent<ILinkable>();
                link.Link(_contexts.game, entity);

                var view = shot.GetComponent<IView>();
                entity.AddView(view);

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