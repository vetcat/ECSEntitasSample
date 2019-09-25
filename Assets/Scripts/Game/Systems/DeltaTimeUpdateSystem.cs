using Entitas;
using Prototype.Scripts;
using UnityEngine;

namespace Game.Systems
{
    public class DeltaTimeUpdateSystem : IExecuteSystem, IPrioritySystem
    {
        public int Priority { get; }
        private GameContext _context;

        public DeltaTimeUpdateSystem(int priority, GameContext context)
        {
            Priority = priority;
            _context = context;
        }

        public void Execute()
        {
            Execute(Time.deltaTime);
        }

        //for unit tests
        public void Execute(float dt)
        {
            _context.deltaTime.Value = dt;
        }
    }
}