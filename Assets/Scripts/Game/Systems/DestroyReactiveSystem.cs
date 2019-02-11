using System.Collections.Generic;
using Entitas;

namespace Game.Systems
{
    public class DestroyReactiveSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _context;

        public DestroyReactiveSystem(GameContext context) : base(context)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Destroy));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroy;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.hasView)
                    entity.view.Value.Destroy();

                entity.Destroy();
            }
        }
    }
}