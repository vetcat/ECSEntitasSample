using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game.Views
{
    public class ShotView : MonoBehaviour, IView, ILinkable, IPositionListener, IRotationListener
    {
        public void Link(IContext context, IEntity entity)
        {
            gameObject.Link(entity, context);
            var e = (GameEntity) entity;
            e.AddPositionListener(this);
            e.AddRotationListener(this);
        }

        public void Destroy()
        {
            gameObject.Unlink();
            Destroy(gameObject);
        }

        public void OnPosition(GameEntity entity, Vector3 value)
        {
            transform.position = value;
        }
		
        public void OnRotation(GameEntity entity, Vector3 value)
        {			
            transform.Rotate(value);			
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Quaternion GetRotation()
        {
            return transform.rotation;
        }
    }
}