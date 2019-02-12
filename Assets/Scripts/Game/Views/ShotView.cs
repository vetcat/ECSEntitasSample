using Entitas;
using Entitas.Unity;
using Game.Settings;
using UnityEngine;

namespace Game.Views
{
    public class ShotView : MonoBehaviour, IShotView, IView, ILinkable, IPositionListener, IRotationListener
    {
        public ShotSettings Settings;        
        
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