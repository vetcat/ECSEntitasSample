using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
	[Game, Unique, CreateAssetMenu]
	public class GameSettings : ScriptableObject
	{
		public GameObject PlayerPrefab;
		public float PlayerMoveSpeed = 5f;// meters per second
		public float PlayerRotationSpeed = 180f; //degrees per second
	}
}