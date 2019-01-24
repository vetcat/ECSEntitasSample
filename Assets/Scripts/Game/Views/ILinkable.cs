using Entitas;

namespace Game.Views
{
	public interface ILinkable
	{
		void Link(IContext context, IEntity entity);
		void Destroy();
	}
}