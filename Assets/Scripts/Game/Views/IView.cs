using UnityEngine;

namespace Game.Views
{
    public interface IView
    {
        void Destroy();
        Vector3 GetPosition();
        void SetPosition(Vector3 position);
        Quaternion GetRotation();
        Vector3 GetForward();
        void SetForward(Vector3 forward);
    }
}