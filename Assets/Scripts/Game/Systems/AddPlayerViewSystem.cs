using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game.Systems
{
	public class AddPlayerViewSystem : ReactiveSystem<GameEntity>
	{
		private Contexts _contexts;

		public AddPlayerViewSystem(Contexts contexts) : base(contexts.game)
		{			
			_contexts = contexts;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position));
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isPlayer && entity.hasPosition;
		}

		protected override void Execute(List<GameEntity> entities)
		{			
			//todo перевести на pool Zenject
			var playerPrefab = _contexts.game.globals.value.PlayerPrefab;

			foreach (var entity in entities)
			{
				var player = GameObject.Instantiate(playerPrefab);
				player.transform.position = entity.position.Value;
			}
		}
	}
}