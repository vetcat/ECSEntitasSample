using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game.Views
{
	public class PlayerView : MonoBehaviour, IView, ILinkable, IPositionListener
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