using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Views.Linkable.Impl
{
	public abstract class LinkableView : MonoBehaviour, ILinkable
	{
		private GameEntity _entity;
		private bool _entityDestroyed;
		private bool _destroyed;

		public int Hash => transform.GetHashCode();

		public virtual void Link(IEntity entity, IContext context)
		{
			_entityDestroyed = false;
			_entity = (GameEntity) entity;
			gameObject.Link(_entity, context);
			_entity.OnDestroyEntity += OnDestroyEntity;
		}

		private void OnDestroyEntity(IEntity entity)
		{
			_entityDestroyed = true;
			entity.OnDestroyEntity -= OnDestroyEntity;
			gameObject.Unlink();
			if (!_destroyed)
				DestroyObject();
		}

		protected virtual void DestroyObject()
		{
#if UNITY_EDITOR
			if (UnityEditor.EditorApplication.isPlaying)
				Destroy(gameObject);
			else
				DestroyImmediate(gameObject);
#else
			Destroy(gameObject);
#endif
		}

		private void OnDestroy()
		{
			_destroyed = true;
			if (!_entityDestroyed && _entity != null)
				OnDestroyEntity(_entity);
		}
	}
}