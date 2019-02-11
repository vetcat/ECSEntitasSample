using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Game.Views;
using UnityEngine;

namespace Game.Systems
{
	public class AddPlayerViewReactiveSystem : ReactiveSystem<GameEntity>
	{
		private Contexts _contexts;

		public AddPlayerViewReactiveSystem(Contexts contexts) : base(contexts.game)
		{			
			_contexts = contexts;
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
			var playerPrefab = _contexts.game.gameSettings.value.PlayerPrefab;

			foreach (var entity in entities)
			{
				var player = GameObject.Instantiate(playerPrefab);
				
				var link = player.GetComponent<ILinkable>();
				link.Link(_contexts.game, entity);

				var view = player.GetComponent<PlayerView>();
				entity.AddPlayerView(view);
				
				entity.ReplacePosition(entity.position.Value);
				entity.ReplaceRotation(entity.rotation.Value);
			}
		}
	}
}