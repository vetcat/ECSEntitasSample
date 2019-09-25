using Entitas;
using Prototype.Scripts;

namespace Input
{
    public class InputStateStandartSystem : IExecuteSystem, IPrioritySystem
    {
        public int Priority { get; }

        private InputContext _context;

        public InputStateStandartSystem(int priority, InputContext context)
        {
            Priority = priority;
            _context = context;
        }

        public void Execute()
        {
            _context.inputState.Horizontal = UnityEngine.Input.GetAxis("Horizontal");
            _context.inputState.Vertical = UnityEngine.Input.GetAxis("Vertical");
            _context.inputState.IsFireProcess = UnityEngine.Input.GetButton("Fire1");
            //_context.inputState.IsSwitchWeaponNext = UnityEngine.Input.GetButtonDown("SwitchWeaponNext");
            //_context.inputState.IsSwitchWeaponPrevious = UnityEngine.Input.GetButtonDown("SwitchWeaponPrevious");
        }
    }
}