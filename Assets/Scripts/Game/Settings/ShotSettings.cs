using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game.Settings
{
	[Game, Unique, CreateAssetMenu]
	public class ShotSettings : ScriptableObject
	{
		public float Speed = 10f;// meters per second		
		public float LifeTime = 2f;
		public int Damage = 20;
	}
}