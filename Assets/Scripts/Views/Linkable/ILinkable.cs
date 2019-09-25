using Entitas;

namespace Views.Linkable
{
    public interface ILinkable
    {
        int Hash { get; }

        void Link(IEntity entity, IContext context);
    }
}