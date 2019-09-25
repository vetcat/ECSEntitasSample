using System.Collections.Generic;
using Entitas;
using Prototype.Scripts;

namespace Game.Systems
{
    public class DestroyReactiveSystem : ReactiveSystem<GameEntity>, IPrioritySystem
    {
        public int Priority { get; }
        private GameContext _context;

        public DestroyReactiveSystem(int priority, GameContext context) : base(context)
        {
            Priority = priority;
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
                entity.Destroy();
            }
        }
    }
}