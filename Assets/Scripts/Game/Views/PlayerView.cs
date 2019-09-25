using Entitas;
using UnityEngine;
using Views.Linkable.Impl;

namespace Game.Views
{
    public class PlayerView : LinkableView, IPlayerView, IRotationListener
    {
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            var e = (GameEntity)entity;
            e.AddRotationListener(this);
        }

        public void OnRotation(GameEntity entity, Quaternion value)
        {
            transform.rotation = value;
        }

        public Vector3 SimpleMove(Vector3 velocity)
        {
            _characterController.SimpleMove(velocity);
            return transform.position;
        }
    }
}