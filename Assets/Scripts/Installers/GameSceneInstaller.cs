using System;
using Game.Settings;
using Game.Systems;
using Input;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameSceneInstaller : MonoInstaller, IDisposable
    {
        private int _systemIndex;

        public override void InstallBindings()
        {
            Debug.Log("[Prototype] InstallBindings");

            SignalBusInstaller.Install(Container);

            BindProviders();
            BindModels();
            BindSignals();
            BindSystems();
        }

        private void BindModels()
        {
        }

        public override void Start()
        {
        }

        private void BindProviders()
        {
        }

        private void BindSystems()
        {
            Container.Bind<IDisposable>().FromInstance(this).AsTransient();

            var settings = Resources.Load("GameSettings") as GameSettings;

            var contexts = Contexts.sharedInstance;

            contexts.game.SetGameSettings(settings);
            contexts.game.SetDeltaTime(0f);
            contexts.input.SetInputState(0f, 0f, false, false, false);

            Container.BindInstance(contexts).WithId(gameObject.name);
            Container.BindInstance(contexts).WhenInjectedInto<GameEventSystems>();

            foreach (var context in contexts.allContexts)
                Container.Bind(context.GetType()).FromInstance(context).AsSingle();

            //game logic systems
            //hi priority
            BindInterfacesAndSelfWithIndex<InitializeSystem>();

            //medium priority
            //reactive system
            BindInterfacesAndSelfWithIndex<AddPlayerViewReactiveSystem>();
            BindInterfacesAndSelfWithIndex<AddShotViewReactiveSystem>();
            //execute system
            BindInterfacesAndSelfWithIndex<DeltaTimeUpdateSystem>();
            BindInterfacesAndSelfWithIndex<InputStateStandartSystem>();
            BindInterfacesAndSelfWithIndex<PlayerMoveSystem>();
            BindInterfacesAndSelfWithIndex<PlayerRotationSystem>();
            BindInterfacesAndSelfWithIndex<PlayerShootingSystem>();
            BindInterfacesAndSelfWithIndex<ShotsMoveSystem>();
            //low priority
            BindInterfacesAndSelfWithIndex<DestroyReactiveSystem>();

            // Event systems
            Container.BindInterfacesAndSelfTo<GameEventSystems>().AsSingle().NonLazy();

            // Cleanup destroyed entity
            //Container.BindDestroyedCleanup<GameContext, GameEntity>(GameMatcher.Destroyed);
            //Container.BindDestroyedCleanup<InputContext, InputEntity>(InputMatcher.Destroyed);
            //Container.BindDestroyedCleanup<ActionContext, ActionEntity>(ActionMatcher.Destroyed);

            // Main Bootstrap
            Container.BindInstance(contexts).WhenInjectedInto<MainBootstrap>();
            Container.BindInterfacesTo<MainBootstrap>().AsSingle().WithArguments(gameObject.name).NonLazy();
        }

        private void BindInterfacesAndSelfWithIndex<T>()
        {
            Container.BindInterfacesAndSelfTo<T>().AsSingle().WithArguments(++_systemIndex);
        }

        private void BindSignals()
        {
            //Container.DeclareSignal<SignalHudTimeSpeedChange>().OptionalSubscriber();
        }

        public void Dispose()
        {

        }
    }
}