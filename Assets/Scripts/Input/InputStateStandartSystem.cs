using Entitas;

namespace Input
{
    public class InputStateStandartSystem : IExecuteSystem
    {
        private InputContext _context;

        public InputStateStandartSystem(InputContext context)
        {
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