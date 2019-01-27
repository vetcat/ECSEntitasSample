using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.Components
{
	[Game, Unique]
	public class DeltaTimeComponent : IComponent
	{
		public float Value;
	}
}