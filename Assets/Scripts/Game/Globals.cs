using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
	[Game, Unique, CreateAssetMenu]
	public class Globals : ScriptableObject
	{
		public GameObject PlayerPrefab;
	}
}