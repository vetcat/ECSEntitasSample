using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Input.Components
{
    [Input, Unique]
    public class InputStateComponent : IComponent
    {
        public float Horizontal;
        public float Vertical;
        public bool IsFireProcess;
        public bool IsSwitchWeaponNext;
        public bool IsSwitchWeaponPrevious;
    }
}