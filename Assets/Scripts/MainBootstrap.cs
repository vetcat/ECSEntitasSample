using System;
using System.Collections.Generic;
using Entitas;
using Prototype.Scripts;
using Zenject;

public class MainBootstrap : IInitializable, ITickable, ILateTickable, IDisposable
{
    private readonly Contexts _contexts;
    private readonly Feature _feature;
    private bool _isInitialized;
    private bool _isPaused;

    public MainBootstrap(string name, Contexts contexts, List<ISystem> systems)
    {
        _contexts = contexts;
        _feature = new Feature($"Bootstrap [{name}]");

        var prioritySystems = new List<IPrioritySystem>();
        var otherSystems = new List<ISystem>();

        foreach (var system in systems)
        {
            if (system is IPrioritySystem)
                prioritySystems.Add((IPrioritySystem)system);
            else
                otherSystems.Add(system);
        }

        prioritySystems.Sort((x, y) => x.Priority.CompareTo(y.Priority));

        foreach (var system in prioritySystems)
        {
            _feature.Add((ISystem) system);
        }

        foreach (var system in otherSystems)
        {
            _feature.Add(system);
        }
    }

    public void Initialize()
    {
        if (_isInitialized)
            throw new Exception("[MainBootstrap] Bootstrap already is initialized");

        _feature.Initialize();
        _isInitialized = true;
    }

    public void Tick()
    {
        if (_isPaused)
            return;

        _feature.Execute();
        _feature.Cleanup();
    }

    public void FixedTick()
    {
        if (_isPaused)
            return;
    }

    public void LateFixed()
    {
        if (_isPaused)
            return;
    }

    public void LateTick()
    {
        if (_isPaused)
            return;

        _feature.Cleanup();
    }

    public void Pause(bool isPaused) => _isPaused = isPaused;

    public void Reset()
    {
        Pause(true);

        Dispose();

        _feature.ActivateReactiveSystems();
        _isInitialized = false;
        Initialize();

        Pause(false);
    }

    public void Dispose()
    {
        _feature.DeactivateReactiveSystems();
        _feature.ClearReactiveSystems();

        foreach (var context in _contexts.allContexts)
        {
            context.DestroyAllEntities();
            context.ResetCreationIndex();
        }
    }
}
