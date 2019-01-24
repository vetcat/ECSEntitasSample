using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.Components
{
	[Game, Event(true)]
	public class HealthComponent : IComponent
	{
		public int Value;
	}
}