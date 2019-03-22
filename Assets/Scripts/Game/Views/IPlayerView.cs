using UnityEngine;

namespace Game.Views
{
    public interface IPlayerView
    {
        Vector3 SimpleMove(Vector3 velocity);
    }
}