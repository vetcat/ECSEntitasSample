using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
	[Game, Unique, CreateAssetMenu]
	public class GameSettings : ScriptableObject
	{
		public GameObject PlayerPrefab;
		public float PlayerSpeed = 5f;
	}
}