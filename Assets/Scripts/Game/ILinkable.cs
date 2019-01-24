using Entitas;

namespace Game
{
	public interface ILinkable
	{
		void Link(IContext context, IEntity entity);
		void Destroy();
	}
}