using UnityEngine;

namespace Game.Views
{
    public interface IPlayerView
    {
        void Destroy();
        Vector3 GetPosition();
        Quaternion GetRotation();
        Vector3 TransformDirection(Vector3 dir);
        void SimpleMove(Vector3 velocity);
    }
}