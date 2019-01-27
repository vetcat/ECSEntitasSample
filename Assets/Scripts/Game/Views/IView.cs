using UnityEngine;

namespace Game.Views
{
	public interface IView
	{
		void Destroy();
		Vector3 GetPosition();
		Quaternion GetRotation();
	}
}