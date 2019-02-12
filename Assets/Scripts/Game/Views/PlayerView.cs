using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game.Views
{
	public class PlayerView : MonoBehaviour, IView, IPlayerView, ILinkable, IPositionListener, IRotationListener
	{
		private CharacterController _characterController;
		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
		}

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

		public Vector3 SimpleMove(Vector3 velocity)
		{
			_characterController.SimpleMove(velocity);
			return transform.position;
		}
	}
}