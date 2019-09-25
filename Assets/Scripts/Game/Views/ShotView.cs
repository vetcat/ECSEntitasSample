using Entitas;
using Game.Settings;
using UnityEngine;

using Views.Linkable.Impl;

namespace Game.Views
{
    public class ShotView : LinkableView, IShotView, IPositionListener, IRotationListener
    {
        public ShotSettings Settings;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            var e = (GameEntity)entity;
            e.AddRotationListener(this);
            e.AddPositionListener(this);
        }

        public void OnPosition(GameEntity entity, Vector3 value)
        {
            transform.position = value;
        }

        public void OnRotation(GameEntity entity, Quaternion value)
        {
            transform.rotation = value;
        }

        public ShotSettings GetSettings()
        {
            return Settings;
        }
    }
}