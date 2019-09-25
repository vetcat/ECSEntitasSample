using System.Collections.Generic;
using Entitas;
using Game.Views;
using Prototype.Scripts;
using UnityEngine;
using Views.Linkable;

namespace Game.Systems
{
    public class AddPlayerViewReactiveSystem : ReactiveSystem<GameEntity>, IPrioritySystem
    {
        public int Priority { get; }
        private readonly GameContext _gameContext;

        public AddPlayerViewReactiveSystem(int priority, GameContext gameContext) : base(gameContext)
        {
            Priority = priority;
            _gameContext = gameContext;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            //todo перевести на pool
            var playerPrefab = _gameContext.gameSettings.value.PlayerPrefab;

            foreach (var entity in entities)
            {
                var player = GameObject.Instantiate(playerPrefab);

                var link = player.GetComponent<ILinkable>();
                link.Link(entity, _gameContext);

                var view = player.GetComponent<IPlayerView>();
                entity.AddPlayerView(view);

                entity.ReplacePosition(entity.position.Value);
                entity.ReplaceRotation(entity.rotation.Value);
            }
        }
    }
}