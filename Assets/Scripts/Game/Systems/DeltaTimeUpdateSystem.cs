using Entitas;
using UnityEngine;

namespace Game.Systems
{
    public class DeltaTimeUpdateSystem : IExecuteSystem
    {
        private GameContext _context;

        public DeltaTimeUpdateSystem(GameContext context)
        {
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