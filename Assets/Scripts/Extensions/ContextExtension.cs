using Entitas;
using Zenject;

namespace Ecs.Extensions
{
    public static class ContextExtension
    {
        public static void BindDestroyedCleanup<TContext, UEntity>(this DiContainer container,
            IMatcher<UEntity> matcher)
            where UEntity : class, IEntity
            where TContext : class, IContext<UEntity>
        {
            container.Bind<IMatcher<UEntity>>().FromInstance(matcher)
                .WhenInjectedInto<DestroyedCleaner<TContext, UEntity>>();
            container.BindInterfacesAndSelfTo<DestroyedCleaner<TContext, UEntity>>().AsSingle().NonLazy();
        }
    }
}